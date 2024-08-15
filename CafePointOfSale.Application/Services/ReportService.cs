using System.Reflection.Metadata.Ecma335;
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

                if (!orders.Any()) 
                {
                    return ResultFactory.Fail<DailySalesSummary>($"No sales made on {date:D}");
                }

                // Initialize summary object
                var summary = new DailySalesSummary 
                {
                    Date = date,
                    TotalOrders = orders.Count,
                    TotalOrderItems = orders.Sum(o => o.OrderItems.Sum(oi => oi.Quantity)), // Aggregate total items
                    TotalRevenue = orders.Sum(o => o.AmountDue ?? 0m),                      // Aggregate total revenue
                    AllOrderItems = orders.SelectMany(o => o.OrderItems).ToList(),          // Flatten all order items
                    ItemSummaries = new()
                };

                // Generate ItemSummaries
                summary.ItemSummaries = summary.AllOrderItems
                    .GroupBy(oi => oi.ItemPrice.Item.ItemName) // Group by item name
                    .Select(g => new ItemSummary
                    {
                        ItemName = g.Key,                      // Use item name as key
                        SoldQuantity = g.Sum(oi => oi.Quantity),
                        ItemRevenue = g.Sum(oi => oi.ExtendedPrice)
                    })
                    .OrderByDescending(g => g.ItemRevenue)
                    .ToList();

                return ResultFactory.Success(summary);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<DailySalesSummary>(ex.Message);
            }
        }
    }
}