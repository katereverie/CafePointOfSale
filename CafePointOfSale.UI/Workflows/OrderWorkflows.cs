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
            var gvaResult = service.GetAvailableCategories();
            if (!gvaResult.Ok || gvaResult.Data == null || !gvaResult.Data.Any())
            {
                Console.WriteLine(gvaResult.Ok ? "Currently, there is no available item category." : gvaResult.Message);
                break;
            }

            var availableCategories = gvaResult.Data;
            IO.PrintAvailableCategories(availableCategories);
            int categoryID = IO.GetCategoryID(availableCategories, "Enter the ID of an available category: ");

            var gaiResult = service.GetAvailableItems(categoryID);
            if (!gaiResult.Ok || !gaiResult.Data.Any())
            {
                Console.WriteLine(gaiResult.Ok ? "Currently, there is no available item." : gaiResult.Message);
                continue;
            }

            var availableItems = gaiResult.Data;
            IO.PrintAvailableItems(availableItems);
            int itemID = IO.GetItemID(availableItems, "Enter the ID of an available item: ");
            byte quantity = IO.GetQuantity("Enter Quantity: ");
            
            if (quantity > 0)
            {
                var itemToAdd = availableItems.Single(i => i.ItemID == itemID);
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

        var atoResult = service.ProcessOrder(order);
        Console.WriteLine(atoResult.Ok ? "Order successfully processed." : atoResult.Message);
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
