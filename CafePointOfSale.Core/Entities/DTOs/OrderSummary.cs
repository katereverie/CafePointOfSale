namespace CafePointOfSale.Core.Entities.DTOs
{
    public class OrderSummary
    {
        public int OrderID { get; set; }
        public byte Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public List<CurrentItem> AddedItems { get; set; }
    }
}
