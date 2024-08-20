using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.UI.Utilities
{
    public static class InputHelper
    {
        public static void AnyKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
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

        public static DateTime GetDate(string prompt) 
        {
            DateTime date;

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

        public static int GetEntityID<T>(List<T> entities, string prompt, Func<T, int>idSelector)
        {
            do
            {
                int id = GetInteger(prompt);
                if (entities.Any(e => idSelector(e) == id))
                {
                    return id;
                }

                Console.WriteLine($"Invalid {typeof(T).Name} ID.");
                AnyKey();
            } while (true);
        }
        public static int GetServerID(List<Server> servers, string prompt)
        {
            return GetEntityID(servers, prompt, s => s.ServerID);
        }

        public static int GetOrderID(List<CafeOrder> orders, string prompt)
        {
            return GetEntityID(orders, prompt, o => o.OrderID);
        }

        public static int GetItemID(List<CurrentItem> items, string prompt)
        {
            return GetEntityID(items, prompt, i => i.ItemID);
        }

        public static int GetCategoryID(List<Category> categories, string prompt)
        {
            return GetEntityID(categories, prompt, c => c.CategoryID);
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

        public static int GetPaymentOption(List<PaymentType> paymentOptions, string prompt)
        {
            do
            {
                int option = GetInteger(prompt);
                if (paymentOptions.Any(po => po.PaymentTypeID == option) || option == 0)
                {
                    return option;
                }

                Console.WriteLine("Invalid option.");
                AnyKey();
            } while (true);
        }

        public static int GetViewOpenOrderOption(string prompt)
        {
            do
            {
                int option = GetInteger(prompt);
                if (option == 0 || option == 1)
                {
                    return option;
                }

                Console.WriteLine("Invalid option.");

            } while (true);
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
