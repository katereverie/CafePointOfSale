using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Entities.DTOs
{
    public class AvailableItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public ItemPrice ItemPrice { get; set; }
    }
}
