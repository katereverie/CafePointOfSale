using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;
using CafePointOfSale.Core.Interfaces.Services;

namespace CafePointOfSale.Application.Services
{
    public class ReportService : IReportService
    {
        private IOrderRepository _orderRepo;

        public ReportService(IOrderRepository orderRepo) 
        {
            _orderRepo = orderRepo;
        }
        public Result<List<CafeOrder>> GetCafeOrdersByDate(DateTime date)
        {
            try
            {
                _orderRepo.GetOrdersByDate();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<CafeOrder>>(ex.Message);
            }
        }
    }
}