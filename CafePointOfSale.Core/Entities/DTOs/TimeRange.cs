namespace CafePointOfSale.Core.Entities.DTOs
{
    public class TimeRange
    {
        public int TimeOfDayID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
