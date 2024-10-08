﻿namespace CafePointOfSale.UI.Utilities
{
    public static class MenuHelper
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1. Manage Orders");
            Console.WriteLine("2. View Reports");
            Console.WriteLine("0. Exit\n");
        }

        public static void DisplayOrderMenu()
        {
            Console.WriteLine("Order Menu\n");
            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. Add Items to Order");
            Console.WriteLine("3. View Open Orders");
            Console.WriteLine("4. Cancel Order");
            Console.WriteLine("5. Process Payment");
            Console.WriteLine("0. Go back\n");
        }

        public static void DisplayReportMenu()
        {
            Console.WriteLine("Report Options\n");
            Console.WriteLine("1. Daily Sales Report");
            Console.WriteLine("2. Monthly Sales Report");
            Console.WriteLine("0. Go back\n");
        }
    }
}
