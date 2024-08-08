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

            if (!gasResult.Ok)
            {
                Console.WriteLine(gasResult.Message);
                IO.AnyKey();
                return;
            }
            else if (gasResult.Data == null || !gasResult.Data.Any())
            {
                Console.WriteLine("Currently, there is server available.");
                IO.AnyKey();
                return;
            }

            var activeServers = gasResult.Data;
            IO.PrintActiveServers(activeServers);

            int serverID = IO.GetServerID(activeServers, "Enter the ID of an available server: ");
            CafeOrder newOrder = new CafeOrder { ServerID = serverID, OrderDate = DateTime.Now, PaymentTypeID = default};
            var coResult = service.CreateOrder(newOrder);

            if (coResult.Ok)
            {
                Console.WriteLine($"New order created with ID {coResult.Data}");
            }
            else
            {
                Console.WriteLine(coResult.Message);
            }

            IO.AnyKey();
        }

        public static void AddItemsToOrder(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();
            if (!gooResult.Ok)
            {
                Console.WriteLine(gooResult.Message);
                IO.AnyKey();
                return;
            }
            else if (gooResult.Data == null || !gooResult.Data.Any())
            {
                Console.WriteLine("Currently, there is no open order.");
                IO.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            IO.PrintOpenOrders(openOrders);
            int orderID = IO.GetOrderID(openOrders, "Enter the ID of an open order: ");
            CafeOrder order = openOrders.Single(op => op.OrderID == orderID);

            List<OrderItem> totalItems = new List<OrderItem>();
            bool hasMoreItemsToAdd = true;

            while (hasMoreItemsToAdd)
            {
                var gvaResult = service.GetAvailableCategories();
                if (!gvaResult.Ok)
                {
                    Console.WriteLine(gvaResult.Message);
                    break;
                }
                else if (gvaResult.Data == null || !gvaResult.Data.Any())
                {
                    Console.WriteLine("Currently, there is no available item category.");
                    break;
                }
                
                var availableCategories = gvaResult.Data;

                do
                {
                    IO.PrintAvailableCategories(availableCategories);
                    int categoryID = IO.GetCategoryID(availableCategories, "Enter the ID of an available category: ");
                    var gaiResult = service.GetAvailableItems(categoryID);
                    if (!gaiResult.Ok)
                    {
                        Console.WriteLine(gaiResult.Message);
                        break;
                    }
                    else if (!gaiResult.Data.Any())
                    {
                        Console.WriteLine("Currently, there is no available item.");
                        break;
                    }

                    var availableItems = gaiResult.Data;
                    IO.PrintAvailableItems(availableItems);
                    int itemID = IO.GetItemID(availableItems, "Enter the ID of an available item: ");
                    byte quantity = IO.GetQuantity("Enter Quantity: ");
                    if (quantity == 0)
                    {
                        continue;
                    }

                    var itemToAdd = availableItems.Single(i => i.ItemID == itemID);

                    OrderItem newOrderItem = new OrderItem
                    {
                        OrderID = orderID,
                        Quantity = quantity,
                        ExtendedPrice = itemToAdd.ItemPrice.Price * quantity,
                        ItemPrice = itemToAdd.ItemPrice
                    };

                    order.OrderItems.Add(newOrderItem);
                    order = service.CalculateSubtotalAndTax(order);
                    IO.PrintOrderSummary(order);

                    hasMoreItemsToAdd = IO.HasMoreItemsToAdd();
                    IO.AnyKey();
                    Console.Clear();

                } while (hasMoreItemsToAdd);

            }

            var atoResult = service.ProcessOrder(order);
            if (atoResult.Ok)
            {
                Console.WriteLine("Order successfully processed.");
            }
            else
            {
                Console.WriteLine(atoResult.Message);
            }

            IO.AnyKey();
        }

        public static void ViewOpenOrders(IOrderService service)
        {
            Console.Clear();

            var gooResult = service.GetOpenOrders();

            if (!gooResult.Ok)
            {
                Console.WriteLine(gooResult.Message);
                IO.AnyKey();
                return;
            }
            else if (!gooResult.Data.Any())
            {
                Console.WriteLine("Currently, there is no open order.");
                IO.AnyKey();
                return;
            }

            var openOrders = gooResult.Data;
            IO.PrintOpenOrders(openOrders);

            do
            {
                int choice = IO.GetInteger("Would you like to view details of a specific order?\n1. Yes\n0. No\nEnter choice: ");
                if (choice == 0)
                {
                    IO.AnyKey();
                    return;
                }
                else if (choice == 1)
                {
                    int orderID = IO.GetOrderID(openOrders, "Enter the ID of the order to view its details: ");
                    var order = openOrders.Find(oo => oo.OrderID == orderID);
                    IO.PrintOrderDetails(order);
                    break;
                }

                Console.WriteLine("Invalid choice.");
            } while (true);

            IO.AnyKey();
        }

        public static void CancelOrder(IOrderService service)
        {
            /*
             * 1. Get open orders via service
             * 2. Display open orders if any
             * 3. Get orderID from user via IO
             * 4. Process delete request via service
             * 5. Display request result
             */
            Console.Clear();




        }

        public static void ProcessPayment(IOrderService service)
        {

        }
    }
}
