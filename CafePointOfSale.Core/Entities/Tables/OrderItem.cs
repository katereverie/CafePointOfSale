using System.ComponentModel.DataAnnotations.Schema;

namespace CafePointOfSale.Core.Entities.Tables
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        [ForeignKey("CafeOrder")]
        public int OrderID { get; set; }
        public int ItemPriceID { get; set; }
        public byte Quantity { get; set; }
        public decimal ExtendedPrice { get; set; }

        public ItemPrice ItemPrice { get; set; }
        public CafeOrder CafeOrder { get; set; }
    }
}
