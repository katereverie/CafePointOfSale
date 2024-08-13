using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Entities.DTOs
{
    public class DailySalesSummary
    {
        public DateTime Date { get; set; }
        public int TotalOrders { get; set; }     
        public int TotalOrderItems { get; set; }
        public decimal TotalRevenue { get; set; }
        public required List<OrderItem> OrderItems { get; set; }
    }
}