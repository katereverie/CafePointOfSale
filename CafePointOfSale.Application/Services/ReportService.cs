using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Interfaces.Repositories;
using CafePointOfSale.Core.Interfaces.Services;

namespace CafePointOfSale.Application.Services
{
    public class ReportService : IReportService
    {
        private ICafeRepository _orderRepo;

        public ReportService(ICafeRepository orderRepo) 
        {
            _orderRepo = orderRepo;
        }
        public Result<DailySalesSummary> GetSalesReportByDate(DateTime date)
        {
            try
            {
                var summary = _orderRepo.GetDailySalesSummary(date);

                return summary != null
                ? ResultFactory.Success(summary)
                : ResultFactory.Fail<DailySalesSummary>($"No sales record on {date:D}");
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<DailySalesSummary>(ex.Message);
            }
        }
    }
}