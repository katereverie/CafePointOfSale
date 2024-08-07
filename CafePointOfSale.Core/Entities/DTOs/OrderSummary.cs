namespace CafePointOfSale.Core.Entities.DTOs
{
    public class OrderSummary
    {
        public int ItemID { get; set; }
        public byte Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ExtendedPrice { get; set; }
    }
}
