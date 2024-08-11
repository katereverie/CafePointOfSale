using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.UI.Utilities
{
    public static class IO
    {
        public static void AnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static void PrintHeader(string header, byte totalSpace)
        {
            string headerSpace = new string(' ', (totalSpace - header.Length) / 2);
            Console.WriteLine("\n" + headerSpace + header + headerSpace + "\n");
        }

        public static int GetInteger(string prompt, int min = 0)
        {
            int result;

            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result >= min)
                    {
                        return result;
                    }

                    Console.WriteLine($"Invalid: Input must be greater than or equal to {min}");
                }

                Console.WriteLine("Invalid: Not an integer");
                AnyKey();
            } while (true);
        }

        public static DateOnly GetDate(string prompt) 
        {
            DateOnly date;

            do
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out date)) 
                {
                    return date;
                }

                Console.WriteLine("Invalid Date format.");
            } while (true);
        }

        public static int GetServerID (List<Server> servers, string prompt)
        {
            do
            {
                int serverID = GetInteger(prompt);
                if (servers.Any(s => s.ServerID == serverID))
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
                int orderID = GetInteger(prompt);
                if (orderList.Any(o => o.OrderID == orderID))
                {
                    return orderID;
                }

                Console.WriteLine("Invalid Order ID");
                AnyKey();
            } while (true);
        }

        public static int GetItemID(List<AvailableItem> items, string prompt)
        {
            do
            {
                int itemID = GetInteger(prompt);
                if (items.Any(i => i.ItemID == itemID))
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

        public static int GetCategoryID(List<Category> categories, string prompt)
        {
            do
            {
                int categoryID = GetInteger(prompt);
                if (categories.Any(c => c.CategoryID == categoryID))
                {
                    return categoryID;
                }

                Console.WriteLine("Invalid Category ID");
                AnyKey();
            } while (true);
        }

        public static void PrintActiveServers(List<Server> servers)
        {
            PrintHeader(" Available Servers ", 30);
            Console.WriteLine($"{"ID", -10} {"Name", -20}");
            Console.WriteLine(new string('=', 30));
            foreach (var s in servers)
            {
                Console.WriteLine($"{s.ServerID, -10} " +
                                  $"{s.LastName + ", " + s.FirstName, -20} ");
            }
            Console.WriteLine();
        }

        public static void PrintOrderDetails(CafeOrder order)
        {
            PrintHeader(" Order Details ", 70);
            Console.WriteLine($"{"Server ID",-10} {"Server Name", -20} {"Order Date", -20} {"Amount Due", -20}");
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"{order.ServerID, -10} " +
                              $"{order.Server.LastName + ", " + order.Server.FirstName, -20} " +
                              $"{order.OrderDate, -20:MM/dd/yyyy} " +
                              $"{(order.AmountDue.HasValue ? order.AmountDue.Value.ToString("C2") : 0), -20}");
            Console.WriteLine();
            PrintOrderedItems(order.OrderItems);
        }

        public static void PrintOpenOrders(List<CafeOrder> orders)
        {
            PrintHeader(" Open Orders ", 40);
            Console.WriteLine($"{"Order ID", -10} {"Server ID", -10} {"Server Name", -20}");
            Console.WriteLine(new string('=', 40));
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderID, -10} " +
                                  $"{order.ServerID, -10} " + 
                                  $"{order.Server.LastName + ", " + order.Server.LastName, -20} ");
            }
            Console.WriteLine();
        }

        public static void PrintAvailableCategories(List<Category> categories)
        {
            PrintHeader(" Category List ", 30);
            Console.WriteLine($"{"ID", -10} {"Category", -20}");
            Console.WriteLine(new string('=', 30));
            foreach(var c in categories)
            {
                Console.WriteLine($"{c.CategoryID, -10} " + 
                                  $"{c.CategoryName, -20} ");
            }
            Console.WriteLine();
        }

        public static void PrintAvailableItems(List<AvailableItem> items)
        {
            PrintHeader(" Available Items ", 100);
            Console.WriteLine($"{"ID",-10} {"Name",-20} {"Price", -10} {"Description",-60}");
            Console.WriteLine(new string('=', 100));
            foreach (var i in items)
            {
                Console.WriteLine($"{i.ItemID,-10} " +
                                  $"{i.ItemName,-20} " +
                                  $"{"$ " + i.ItemPrice.Price,-10}" +
                                  $"{(i.ItemDescription.Length > 57 ? i.ItemDescription.Substring(0, 56) + "..." : i.ItemDescription),-60}");
            }
            Console.WriteLine();
        }

        public static void PrintOrderSummary(CafeOrder order)
        {
            Console.Clear();
            PrintHeader(" Order Summary ", 50);
            Console.WriteLine(" General Summary ");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"{"Server ID",-10} {"Status",-10} {"Subtotal",-15} {"Tax",-15}");
            Console.WriteLine($"{order.ServerID,-10} " +
                              $"{(order.PaymentTypeID == null ? "Pending" : "Closed"),-10} " +
                              $"{order.SubTotal.Value.ToString("C2"),-15} " +
                              $"{order.Tax.Value.ToString("C2"),-15}");
            Console.WriteLine();
            PrintOrderedItems(order.OrderItems);
        }


        public static void PrintOrderedItems(List<OrderItem> items) 
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Ordered Items: none");
            }
            else
            {
                PrintHeader(" Ordered Items ", 55);
                Console.WriteLine($"{"Item Name",-25} {"Quantity",-10} {"Extended Price",-10}");
                Console.WriteLine(new string('=', 55));
                foreach (var oi in items)
                {
                    Console.WriteLine($"{oi.ItemPrice.Item.ItemName,-25} " +
                                      $"{oi.Quantity,-10} "  +
                                      $"{oi.ExtendedPrice,-10} ");
                }
            }
        }

        public static bool HasMoreItemsToAdd()
        {
            do
            {
                Console.WriteLine("\nWould you like to add more items?");
                int choice = GetInteger("1. Add another item\n2. Submit Order\nEnter choice: ", 1);
                switch (choice)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Console.WriteLine("Invalid choice.");
                        continue;
                }
            } while (true);
        }
    }
}
