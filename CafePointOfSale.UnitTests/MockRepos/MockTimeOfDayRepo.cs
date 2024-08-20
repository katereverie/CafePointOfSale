using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.UnitTests.MockRepos
{
    public class MockTimeOfDayRepo : ITimeOfDayRepository
    {
        public DateTime CurrentTime { get; } = new DateTime(2024, 8, 20);

        // default to returning lunch
        public int? GetTimeOfDayID()
        {
            return 2;
        }
    }
}
