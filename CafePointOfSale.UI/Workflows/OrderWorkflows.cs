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
                InputHelper.AnyKey();
                return;
            }

            var activeServers = gasResult.Data;
            DisplayHelper.DisplayActiveServers(activeServers);

            int serverID = InputHelper.GetServerID(activeServers, "Enter the ID of an available server: ");
            CafeOrder newOrder = new CafeOrder 
            {   ServerID = serverID, 
                OrderDate = DateTime.Now, 
                PaymentTypeID = default
            };
            var coResult = service.CreateOrder(newOrder);
            
            Console.WriteLine(coResult.Ok ? $"New order created with ID {coResult.Data}" : coResult.Message);
            InputHelper.AnyKey();
        }
        public static void AddItemsToOrder(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();
            if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any())
            {
                Console.WriteLine(gooResult.Ok ? "Currently, there is no open order." : gooResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            DisplayHelper.DisplayOpenOrders(openOrders);
            int orderID = InputHelper.GetOrderID(openOrders, "Enter the ID of an open order: ");
            CafeOrder order = openOrders.Single(op => op.OrderID == orderID);
            var gaciResult = service.GetAllCurrentItems();
            if (!gaciResult.Ok || gaciResult.Data == null || !gaciResult.Data.Any())
            {
                Console.WriteLine(gaciResult.Ok ? "At current time, there is no available item." : gaciResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var allCurrentItems = gaciResult.Data;
            var allCurrentCategories = allCurrentItems.GroupBy(i => i.Category.CategoryID).Select(g => g.First().Category).ToList();

            bool continueAddingItems = true;
            while (continueAddingItems)
            {
                DisplayHelper.DisplayCurrentCategories(allCurrentCategories);
                int categoryID = InputHelper.GetCategoryID(allCurrentCategories, "Enter the ID of an available category: ");

                var currentItemsByCategory = allCurrentItems.Where(i => i.Category.CategoryID == categoryID).ToList();
                DisplayHelper.DisplayCurrentItems(currentItemsByCategory);
                int itemID = InputHelper.GetItemID(currentItemsByCategory, "Enter the ID of an available item: ");

                byte quantity = InputHelper.GetQuantity("Enter Quantity: ");
                if (quantity == 0)
                {
                    return;
                }

                // 1. Add more of an existing item
                if (order.OrderItems.Any(oi => oi.ItemPrice.ItemID == itemID))
                {
                    var existingItem = order.OrderItems.Single(oi => oi.ItemPrice.Item.ItemID == itemID);
                    existingItem.Quantity += quantity;
                    existingItem.ExtendedPrice = existingItem.ItemPrice.Price * existingItem.Quantity;
                }
                // 2. Add a new item
                else
                {
                    var selectedCurrentItem = currentItemsByCategory.Single(i => i.ItemID == itemID);

                    var newOrderItem = new OrderItem
                    {
                        OrderID = orderID,
                        Quantity = quantity,
                        ExtendedPrice = selectedCurrentItem.ItemPrice.Price * quantity,
                        ItemPrice = selectedCurrentItem.ItemPrice
                    };

                    order.OrderItems.Add(newOrderItem);
                }

                order = service.CalculateOrderTotals(order);
                DisplayHelper.DisplayOrderSummary(order);
                
                continueAddingItems = InputHelper.HasMoreItemsToAdd();
            }

            var soResult = service.SubmitOrder(order);
            Console.WriteLine(soResult.Ok ? "Order successfully submitted." : soResult.Message);
            InputHelper.AnyKey();
        }

        public static void ViewOpenOrders(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();
            if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any())
            {
                Console.WriteLine(gooResult.Ok ? "Currently, there is no open order." : gooResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            DisplayHelper.DisplayOpenOrders(openOrders);

            int option = InputHelper.GetViewOpenOrderOption("Would you like to view details of a specific order?\n1. Yes\n0. No, I'd like to return\nEnter choice: ");                
            switch (option) 
            {
                case 0:
                    break;
                case 1:
                    int orderID = InputHelper.GetOrderID(openOrders, "Enter the ID of the order to view its details: ");
                    var order = openOrders.Single(oo => oo.OrderID == orderID);
                    DisplayHelper.DisplayOrderDetails(order);
                    break;
            }

            InputHelper.AnyKey();
        }
        public static void CancelOrder(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();

            if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any()) 
            {
                Console.WriteLine(gooResult.Ok ? "Currently, there is no open order to cancel." : gooResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            DisplayHelper.DisplayOpenOrders(openOrders);
            int orderID = InputHelper.GetOrderID(openOrders, "Enter the ID of an open order: ");

            var coResult = service.CancelOrder(orderID);
            Console.WriteLine(coResult.Ok ? "Order Successfully cancelled." : coResult.Message);

            InputHelper.AnyKey();
        }

        public static void ProcessPayment(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();
            if (!gooResult.Ok || gooResult.Data == null || !gooResult.Data.Any())
            {
                Console.WriteLine(gooResult.Ok ? "Currently, there is no open order to process." : gooResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            DisplayHelper.DisplayOpenOrders(openOrders);
            int orderID = InputHelper.GetOrderID(openOrders, "Enter the ID of an open order: ");
            CafeOrder order = openOrders.Single(op => op.OrderID == orderID);

            var gptResult = service.GetPaymentTypes();
            if (!gptResult.Ok || gptResult.Data == null || !gptResult.Data.Any())
            {
                Console.WriteLine(gptResult.Ok ? "Currently, there is no available payment option." : gooResult.Message);
                InputHelper.AnyKey();
                return;
            }

            var paymentOptions = gptResult.Data;
            DisplayHelper.DisplayPaymentOptions(paymentOptions);
            int paymentOption = InputHelper.GetPaymentOption(paymentOptions, "Enter a Payment Option or 0 to return: ");

            if (paymentOption == 0) return;

            var apmResult = service.AddPaymentMethod(order, paymentOption);
            Console.WriteLine(apmResult.Ok ? $"Payment method added to order {order.OrderID}" : apmResult.Message);
            InputHelper.AnyKey();
        }
    }
}
