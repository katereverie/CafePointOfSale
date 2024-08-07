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

        public static int GetItemID(List<Item> itemList, string prompt)
        {
            do
            {
                int itemID = GetPositiveInteger(prompt);
                if (itemList.Any(i => i.ItemID == itemID))
                {
                    return itemID;
                }

                Console.WriteLine("Invalid Order ID");
                AnyKey();
            } while (true);
        }

        public static byte GetQuantity(string prompt)
        {
            byte quantity;

            do
            {
                Console.Write(prompt);
                if (byte.TryParse(Console.ReadLine(), out quantity))
                {
                    if (quantity >= 0 && quantity < 100)
                    {
                        return quantity;
                    }
                    else
                    {
                        Console.WriteLine("Quantity too big.");
                    }
                }

                Console.WriteLine("Invalid Quantity input.");
                AnyKey();
            } while (true);
        }

        public static int GetCategoryID(List<Category> availableCategories, string prompt)
        {
            throw new NotImplementedException();
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

        public static void PrintAvailableItems(List<Item> itemList)
        {
            throw new NotImplementedException();
        }

        public static void PrintOrderSummary(List<OrderItem> totalItems)
        {
            throw new NotImplementedException();
        }

        internal static bool HasMoreItemsToAdd()
        {
            throw new NotImplementedException();
        }
    }
}
