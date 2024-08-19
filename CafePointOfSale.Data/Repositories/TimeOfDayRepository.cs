using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.Data.Repositories
{
    public class TimeOfDayRepository : ITimeOfDayRepository
    {
        public DateTime CurrentTime { get { return DateTime.Now; } }
        public List<(int, TimeSpan, TimeSpan)> TimeRanges { get; }

        public TimeOfDayRepository(string connectionString)
        {
            TimeRanges = new List<(int TimeOfDayID, TimeSpan StartTime, TimeSpan EndTime)>
            {
                (1, new TimeSpan(6, 30, 0), new TimeSpan(11, 30, 00)),  // Breakfast: 6:30 to 10:30 
                (2, new TimeSpan(11, 30, 0), new TimeSpan(16, 0, 0)), // Lunch: 11:30 to 15:00
                (3, new TimeSpan(16, 0, 0), new TimeSpan(18, 30, 0)), // Happy Hour: 16:00 - 19:00
                (4, new TimeSpan(18, 30, 0), new TimeSpan(22, 30, 00)) // Dinner: 18:00 - 22:30
            };
        }

        public int? GetTimeOfDayID()
        {
            var currentTimeOnly = CurrentTime.TimeOfDay;

            foreach (var (timeOfDayID, startTime, endTime) in TimeRanges)
            {
                if (startTime <= currentTimeOnly && currentTimeOnly <= endTime)
                {
                    return timeOfDayID;
                }
            }

            return null;
        }
    }
}