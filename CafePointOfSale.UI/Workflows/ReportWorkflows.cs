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
            * 2. (x) Get all orders and their items on given Date
            * 3. (x) Display fetched orders and their itens via IO
            */
            Console.Clear();
            DateTime date = IO.GetDate("Enter a Date to view the sales report on the date: ");

            var gsrbdResult = service.GetSalesReportByDate(date);

            if (!gsrbdResult.Ok || gsrbdResult.Data == null) 
            {
                Console.WriteLine(gsrbdResult.Ok ? $"No Sales Report available on {date}" : gsrbdResult.Message);
            }
            else 
            {
                IO.PrintDailySalesReport(gsrbdResult.Data);
            }

            IO.AnyKey();
        }
    }
}