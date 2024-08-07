using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.UI.Utilities
{
    public static class IO
    {
        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void PrintHeader(string header)
        {
            string headerSpace = new string(' ', (100 - header.Length) / 2);
            Console.WriteLine("\n" + headerSpace + header + headerSpace + "\n");
        }

        public static int GetPositiveInteger(string prompt)
        {
            int result;

            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result > 0)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input, must be a positive integer!");
                AnyKey();
            } while (true);
        }

        public static int GetServerID (List<Server> serverList, string prompt)
        {
            do
            {
                int serverID = GetPositiveInteger(prompt);
                if (serverList.Any(s => s.ServerID == serverID))
                {
                    return serverID;
                }

                Console.WriteLine("Invalid Server ID.");
                AnyKey();
            } while (true);
        }


        public static int GetOrderID(List<CafeOrder> orderList, string prompt)
        {
            do
            {
                int orderID = GetPositiveInteger(prompt);
                if (orderList.Any(o => o.OrderID == orderID))
                {
                    return orderID;
                }

                Console.WriteLine("Invalid Order ID");
                AnyKey();
            } while (true);
        }

        public static void PrintActiveServers(List<Server> serverList)
        {
            throw new NotImplementedException();
        }

        public static void PrintOpenOrders(List<CafeOrder> orders)
        {
            throw new NotImplementedException();
        }

        public static void PrintAvailableCategories(List<Category> data)
        {
            throw new NotImplementedException();
        }

        public static int GetCategoryID(List<Category> availableCategories, string v)
        {
            throw new NotImplementedException();
        }
    }
}
