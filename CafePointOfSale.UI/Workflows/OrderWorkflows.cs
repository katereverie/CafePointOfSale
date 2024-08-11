using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Services;
using CafePointOfSale.UI.Utilities;

namespace CafePointOfSale.UI.Workflows
{
    public static class OrderWorkflows
    {
        public static void CreateOrder(IOrderService service)
        {
            Console.Clear();

            var gasResult = service.GetActiveServers();

            if (!gasResult.Ok || gasResult.Data == null || !gasResult.Data.Any())
            {
                Console.WriteLine(gasResult.Ok ? "Currently, there is server available." : gasResult.Message);
                IO.AnyKey();
                return;
            }

            var activeServers = gasResult.Data;
            IO.PrintActiveServers(activeServers);

            int serverID = IO.GetServerID(activeServers, "Enter the ID of an available server: ");
            CafeOrder newOrder = new CafeOrder { ServerID = serverID, OrderDate = DateTime.Now, PaymentTypeID = default};
            var coResult = service.CreateOrder(newOrder);
            
            Console.WriteLine(coResult.Ok ? $"New order created with ID {coResult.Data}" : coResult.Message);
            IO.AnyKey();
        }

    public static void AddItemsToOrder(IOrderService service)
    {
        Console.Clear();

        var gooResult = service.GetOpenOrders();
        if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any())
        {
            Console.WriteLine(gooResult.Ok ? "Currently, there is no open order." : gooResult.Message);
            IO.AnyKey();
            return;
        }

        var openOrders = gooResult.Data;
        IO.PrintOpenOrders(openOrders);
        int orderID = IO.GetOrderID(openOrders, "Enter the ID of an open order: ");
        CafeOrder order = openOrders.Single(op => op.OrderID == orderID);

        bool continueAddingItems = true;
        while (continueAddingItems)
        {
            var gaciResult = service.GetAllCurrentItems();
            if (!gaciResult.Ok || !gaciResult.Data.Any())
            {
                Console.WriteLine(gaciResult.Ok ? "At current time, there is no available item." : gaciResult.Message);
                continue;
            }

            var allCurrentItems = gaciResult.Data;
            var allCurrentCategories = allCurrentItems.Where(i => i.Category).ToList();

            IO.PrintAvailableCategories(allCurrentCategories);
            int categoryID = IO.GetCategoryID(allCurrentCategories, "Enter the ID of an available category: ");

            var currentItemsByCategory = allCurrentItems.Where(i => i.Category.CategoryID == categoryID).ToList();
            IO.PrintAvailableItems(currentItemsByCategory);
            int itemID = IO.GetItemID(currentItemsByCategory, "Enter the ID of an available item: ");

            byte quantity = IO.GetQuantity("Enter Quantity: ");
            if (quantity > 0)
            {
                var itemToAdd = currentItemsByCategory.Single(i => i.ItemID == itemID);
                order.OrderItems.Add(new OrderItem
                {
                    OrderID = orderID,
                    Quantity = quantity,
                    ExtendedPrice = itemToAdd.ItemPrice.Price * quantity,
                    ItemPrice = itemToAdd.ItemPrice
                });

                order = service.CalculateSubtotalAndTax(order);
                IO.PrintOrderSummary(order);
            }

            continueAddingItems = IO.HasMoreItemsToAdd();
        }

        var poResult = service.ProcessOrder(order);
        Console.WriteLine(poResult.Ok ? "Order successfully processed." : poResult.Message);
        IO.AnyKey();
    }

        public static void CancelOrder(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();

            if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any()) 
            {
                Console.WriteLine(gooResult.Ok ? "Currently, there is no open order to cancel." : gooResult.Message);
                IO.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            IO.PrintOpenOrders(openOrders);
            int orderID = IO.GetOrderID(openOrders, "Enter the ID of an open order: ");

            var coResult = service.CancelOrder(orderID);

            Console.WriteLine(coResult.Ok ? "Order Successfully cancelled." : coResult.Message);
            IO.AnyKey();
        }

        public static void ProcessPayment(IOrderService service)
        {
            
        }
    }
}
