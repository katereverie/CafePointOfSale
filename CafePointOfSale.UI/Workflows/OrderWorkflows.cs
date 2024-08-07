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
            CafeOrder newOrder = new CafeOrder { ServerID = serverID };
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
            /*
             * 1. Display open orders if any (x)
             * 2. Get orderID from user via IO (x)
             * 3. Initiate a List of order items
             * 4. Start a loop 
             *    a. Display available categories
             *    b. User may choose to exit (enter 0) loop
             *    c. Get categoryID from user via IO
             *    d. Display available items based on chosen categoryID
             *    e. Get itemID and quantity from user via IO
             *    f. Initiate OrderItem based on e
             *    g. Add OrderItem to List
             *    h. Prompt user for adding more or quit adding 
             * 5. Invoke AddItemsToOrder
             * 6. Display result + order summary 
             */

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

            List<OrderItem> items = new List<OrderItem>();
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
                IO.PrintAvailableCategories(availableCategories);
                int categoryID = IO.GetCategoryID(availableCategories, "Enter the ID of an available category: ");
                service.GetAvailableItems(categoryID)
            }


            

        }

        public static void ViewOpenOrders(IOrderService service)
        {

        }

        public static void CancelOrder(IOrderService service)
        {

        }

        public static void ProcessPayment(IOrderService service)
        {

        }
    }
}
