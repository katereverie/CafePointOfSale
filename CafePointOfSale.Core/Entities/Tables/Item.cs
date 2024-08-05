namespace CafePointOfSale.Core.Entities.Tables
{
    public class Item
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public Category Category { get; set; }
        public List<ItemPrice> Prices { get; set; }
    }
}
