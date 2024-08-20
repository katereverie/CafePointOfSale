using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.UI.Utilities
{
    public static class DisplayHelper
    {
        public static void DisplayHeader(string header, byte totalSpace)
        {
            string headerSpace = new string(' ', (totalSpace - header.Length) / 2);
            Console.WriteLine("\n" + headerSpace + header + headerSpace + "\n");
        }

        public static void DisplayActiveServers(List<Server> servers)
        {
            DisplayHeader(" Available Servers ", 30);
            Console.WriteLine($"{"ID",-10} {"Name",-20}");
            Console.WriteLine(new string('=', 30));
            foreach (var s in servers)
            {
                Console.WriteLine($"{s.ServerID,-10} " +
                                  $"{s.LastName + ", " + s.FirstName,-20} ");
            }
            Console.WriteLine();
        }

        public static void DisplayOrderDetails(CafeOrder order)
        {
            DisplayHeader(" Order Details ", 100);
            Console.WriteLine($"{"Server ID",-20} {"Server Name",-30} {"Order Date",-30} {"Total Amount",-30}");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"{order.ServerID,-20} " +
                              $"{order.Server.LastName + ", " + order.Server.FirstName,-30} " +
                              $"{order.OrderDate,-30:MM/dd/yyyy} " +
                              $"{(order.AmountDue.HasValue ? order.AmountDue.Value.ToString("C2") : 0),-30}");
            Console.WriteLine();
            DisplayOrderedItems(order.OrderItems);
        }

        public static void DisplayOpenOrders(List<CafeOrder> orders)
        {
            DisplayHeader(" Open Orders ", 60);
            Console.WriteLine($"{"Order ID",-15} {"Server ID",-15} {"Server Name",-30}");
            Console.WriteLine(new string('=', 60));
            foreach (var order in orders)
            {
                Console.WriteLine($"{order.OrderID,-15} " +
                                  $"{order.ServerID,-15} " +
                                  $"{order.Server.LastName + ", " + order.Server.FirstName,-30} ");
            }
            Console.WriteLine();
        }

        public static void DisplayCurrentCategories(List<Category> categories)
        {
            DisplayHeader(" Category List ", 30);
            Console.WriteLine($"{"ID",-10} {"Category",-20}");
            Console.WriteLine(new string('=', 30));
            foreach (var c in categories)
            {
                Console.WriteLine($"{c.CategoryID,-10} " +
                                  $"{c.CategoryName,-20} ");
            }
            Console.WriteLine();
        }

        public static void DisplayCurrentItems(List<CurrentItem> items)
        {
            DisplayHeader(" Current Items ", 100);
            Console.WriteLine($"{"ID",-10} {"Name",-20} {"Price",-10} {"Description",-60}");
            Console.WriteLine(new string('=', 100));
            foreach (var i in items)
            {
                Console.WriteLine($"{i.ItemID,-10} " +
                                  $"{i.ItemName,-20} " +
                                  $"{"$ " + i.ItemPrice.Price,-10} " +
                                  $"{(i.ItemDescription.Length > 57 ? i.ItemDescription.Substring(0, 56) + "..." : i.ItemDescription),-60} ");
            }
            Console.WriteLine();
        }

        public static void DisplayOrderSummary(CafeOrder order)
        {
            Console.Clear();
            DisplayHeader(" Order Summary ", 60);
            Console.WriteLine($"{"Server ID",-10} {"Status",-10} {"Subtotal",-15} {"Tax",-15}");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"{order.ServerID,-10} " +
                              $"{(order.PaymentTypeID == null ? "Pending" : "Closed"),-10} " +
                              $"{(order.SubTotal.HasValue ? order.SubTotal.Value.ToString("C2") : 0),-15} " +
                              $"{(order.Tax.HasValue ? order.Tax.Value.ToString("C2") : 0),-15}");
            Console.WriteLine();
            DisplayOrderedItems(order.OrderItems);
        }

        public static void DisplayOrderedItems(List<OrderItem>? orderItems)
        {
            if (orderItems == null || orderItems.Count == 0)
            {
                Console.WriteLine("Ordered Items: none");
            }
            else
            {
                DisplayHeader(" Ordered Items ", 100);
                Console.WriteLine($"{"Item Name",-30} {"Quantity",-30} {"Extended Price",-30}");
                Console.WriteLine(new string('=', 100));
                foreach (var oi in orderItems)
                {
                    Console.WriteLine($"{oi.ItemPrice.Item.ItemName,-30} " +
                                        $"{oi.Quantity,-30} " +
                                        $"{oi.ExtendedPrice,-30} ");
                }
            }

            Console.WriteLine();
        }

        public static void DisplayPaymentOptions(List<PaymentType> paymentOptions)
        {
            DisplayHeader(" Payment Options ", 40);
            Console.WriteLine($"{"Option",-10} {"Payment Method",-20}");
            Console.WriteLine(new string('=', 40));
            foreach (var po in paymentOptions)
            {
                Console.WriteLine($"{po.PaymentTypeID,-10} " +
                                  $"{po.PaymentTypeName,-20} ");
            }
            Console.WriteLine();
        }

        public static void DisplayDailySalesReport(DailySalesSummary summary)
        {
            DisplayHeader($"{summary.Date:D}", 100);
            DisplayHeader($" Daily Sales Summary", 100);
            Console.WriteLine($"{"Total Orders",-30} {"Total Order Items",-30} {"Total Revenue ($)",-30}");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine($"{summary.TotalOrders,-30} " +
                              $"{summary.TotalOrderItems,-30} " +
                              $"{summary.TotalRevenue,-30} ");
            Console.WriteLine();
            DisplayHeader($" Sold Items Summary ", 100);
            Console.WriteLine($"{"Name",-30} {"Sold Quantity",-30} {"Revenue ($)",-30}");
            Console.WriteLine(new string('=', 100));
            foreach (var itemSummary in summary.ItemSummaries)
            {
                Console.WriteLine($"{itemSummary.ItemName,-30} " +
                                  $"{itemSummary.SoldQuantity,-30} " +
                                  $"{itemSummary.ItemRevenue,-30}");
            }
            Console.WriteLine();
        }
    }
}
