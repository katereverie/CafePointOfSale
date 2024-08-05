namespace CafePointOfSale.Core.Entities.Tables
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Item> Items { get; set; }
    }
}
