namespace CafePointOfSale.UI.Utilities
{
    public static class Menus
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1. Manage Orders");
            Console.WriteLine("2. Manage Payment");
            Console.WriteLine("3. View Reports");
            Console.WriteLine("0. Exit");
        }

        public static void DisplayOrderMenu()
        {
            Console.WriteLine("Order Menu\n");
            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. Add Items to Order");
            Console.WriteLine("3. View Open Orders");
            Console.WriteLine("4. Cancel Order");
            Console.WriteLine("0. Go back");
        }

        public static void DisplayPaymentMenu()
        {
            Console.WriteLine("Payment Management\n");
            Console.WriteLine("1. Process Payment");
            Console.WriteLine("0. Go back");
        }

        public static void DisplayReportMenu()
        {
            Console.WriteLine("Report Options\n");
            Console.WriteLine("1. Daily Sales Report");
            Console.WriteLine("0. Go back");
        }
    }
}
