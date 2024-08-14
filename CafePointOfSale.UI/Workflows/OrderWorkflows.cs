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
            CafeOrder newOrder = new CafeOrder 
            {   ServerID = serverID, 
                OrderDate = DateTime.Now, 
                PaymentTypeID = default, 
                Server = activeServers.Single(s => s.ServerID == serverID),
                OrderItems = new()
            };
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
                if (!gaciResult.Ok || gaciResult.Data == null || !gaciResult.Data.Any())
                {
                    Console.WriteLine(gaciResult.Ok ? "At current time, there is no available item." : gaciResult.Message);
                    continue;
                }

                var allCurrentItems = gaciResult.Data;
                var allCurrentCategories = allCurrentItems.Select(i => i.Category).ToList();

                IO.PrintAvailableCategories(allCurrentCategories);
                int categoryID = IO.GetCategoryID(allCurrentCategories, "Enter the ID of an available category: ");

                var currentItemsByCategory = allCurrentItems.Where(i => i.Category.CategoryID == categoryID).ToList();
                IO.PrintCurrentItems(currentItemsByCategory);
                int itemID = IO.GetItemID(currentItemsByCategory, "Enter the ID of an available item: ");

                byte quantity = IO.GetQuantity("Enter Quantity: ");
                if (quantity > 0)
                {
                    var itemToAdd = currentItemsByCategory.Single(i => i.ItemID == itemID);
                    order.OrderItems?.Add(new OrderItem
                    {
                        OrderID = orderID,
                        Quantity = quantity,
                        ExtendedPrice = itemToAdd.ItemPrice.Price * quantity,
                        ItemPrice = itemToAdd.ItemPrice,
                        CafeOrder = order
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

        public static void ViewOpenOrders(IOrderService service)
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

            do
            {
                int choice = IO.GetInteger("Would you like to view details of a specific order?\n1. Yes\n2. No, I'd like to return");                
                switch (choice) 
                {
                    case 0:
                        IO.AnyKey();
                        return;
                    case 1:
                        int orderID = IO.GetOrderID(openOrders, "Enter the ID of the order to view its details: ");
                        var order = openOrders.Single(oo => oo.OrderID == orderID);
                        IO.PrintOrderDetails(order);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }

                break;

            } while (true);

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
            // 1. (x) Get open orders via service
            // 2. (x) display open orders via IO
            // 3. (x) Get orderID from users via IO
            // 4. (x) Get payment types via service
            // 5. (x) display payment types via IO
            // 6. Get payment type option from users via IO
            // 7. add chosen payment type ID to chosen order via service

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

            var gptResult = service.GetPaymentTypes();
            if (!gptResult.Ok || gptResult.Data == null || !gptResult.Data.Any())
            {
                Console.WriteLine(gptResult.Ok ? "Currently, there is no available payment option." : gooResult.Message);
                IO.AnyKey();
                return;
            }

            var paymentOptions = gptResult.Data;
            IO.PrintPaymentOptions(paymentOptions);
            int paymentOption = IO.GetPaymentOption(paymentOptions, "Enter a Payment Option or 0 to return: ");

            if (paymentOption == 0) 
            {
                return;
            }

            var apmResult = service.AddPaymentMethod(order, paymentOption);
            Console.WriteLine(apmResult.Ok ? $"Payment method added to order {order.OrderID}" : apmResult.Message);
        }
    }
}
