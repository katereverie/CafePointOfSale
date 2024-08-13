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
        public Result<DailySalesSummary> GetSalesReportByDate(DateTime date)
        {
            try
            {
                var orders = _orderRepo.GetOrdersByDate(date);

                int totalOrderItems = 0;
                decimal totalRevenue = 0m;
                orders.ForEach(o => o.OrderItems.ForEach(oi => totalOrderItems += oi.Quantity));
                orders.ForEach(o => totalRevenue += o.AmountDue ?? 0);

                var summary = new DailySalesSummary 
                {
                    Date = date,
                    TotalOrders = orders.Count,
                    TotalOrderItems = totalOrderItems,
                    TotalRevenue = totalRevenue,
                    OrderItems = new(),
                    TopThreeItems = new()
                };

                orders.ForEach(o => o.OrderItems.ForEach(oi => summary.OrderItems.Add(oi)));
                var sortedOrderItems = summary.OrderItems.OrderByDescending(oi => oi.ExtendedPrice).ToList();
                summary.TopThreeItems.AddRange(sortedOrderItems);

                return ResultFactory.Success(summary);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<DailySalesSummary>(ex.Message);
            }
        }
    }
}