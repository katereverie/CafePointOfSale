using CafePointOfSale.UI.Utilities;

namespace CafePointOfSale.UI.Workflows
{
    public static class ReportWorkflows
    {
        public static void GetDailySalesReport()
        {
            /* 
            * 1. Get a Date from users via IO
            * 2. Get all orders and their items on given Date
            * 3. Display fetched orders and their itens via IO
            */
            Console.Clear();
            DateTime date = IO.GetDate("Enter a Date to view the sales report on the date: ");

            // Each date may have several orders. 
            // Each order may have several items
            // Decide what to display and how to display them

        }
    }
}