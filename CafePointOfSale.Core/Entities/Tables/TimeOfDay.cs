namespace CafePointOfSale.Core.Entities.Tables
{
    public class TimeOfDay
    {
        public int TimeOfDayID { get; set; }
        public string TimeOfDayName { get; set; }

        public List<ItemPrice> ItemPrices { get; set; }
    }
}
