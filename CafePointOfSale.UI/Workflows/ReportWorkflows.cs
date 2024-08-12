using CafePointOfSale.Core.Interfaces.Services;
using CafePointOfSale.UI.Utilities;

namespace CafePointOfSale.UI.Workflows
{
    public static class ReportWorkflows
    {
        public static void GetDailySalesReport(IReportService service)
        {
            /* 
            * 1. (x) Get a Date from users via IO
            * 2. Get all orders and their items on given Date
            * 3. Display fetched orders and their itens via IO
            */
            Console.Clear();
            DateTime date = IO.GetDate("Enter a Date to view the sales report on the date: ");

            // Each date may have several orders. 
            // Each order may have several items
            // Decide what to display and how to display them

            var gcobdResult = service.GetCafeOrdersByDate(date);

            if (!gcobdResult.Ok || gcobdResult.Data == null || !gcobdResult.Data.Any()) 
            {
                Console.WriteLine(gcobdResult.Ok ? $"No Sales Report available on {date}" : gcobdResult.Message);
            }
            else 
            {
                IO.PrintDailySalesReport(gcobdResult.Data);
            }

            IO.AnyKey();
        }
    }
}