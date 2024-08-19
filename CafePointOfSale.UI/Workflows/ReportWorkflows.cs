using CafePointOfSale.Core.Interfaces.Services;
using CafePointOfSale.UI.Utilities;

namespace CafePointOfSale.UI.Workflows
{
    public static class ReportWorkflows
    {
        public static void GetDailySalesReport(IReportService service)
        {
            Console.Clear();
            
            DateTime date = IO.GetDate("Enter a Date to view the sales report on the date: ");

            var gsrbdResult = service.GetSalesReportByDate(date);

            if (!gsrbdResult.Ok || gsrbdResult.Data == null) 
            {
                Console.WriteLine(gsrbdResult.Message);
            }
            else 
            {
                IO.PrintDailySalesReport(gsrbdResult.Data);
            }

            IO.AnyKey();
        }
    }
}