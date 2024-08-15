namespace CafePointOfSale.Core.Entities.DTOs
{
    public class ItemSummary
    {
        public string ItemName { get; set; }
        public int SoldQuantity { get; set; }
        public decimal ItemRevenue { get; set; }
    }
}