using CafePointOfSale.Core.Entities.DTOs;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IReportService
    {
        Result<DailySalesSummary> GetSalesReportByDate(DateTime date);
    }
}