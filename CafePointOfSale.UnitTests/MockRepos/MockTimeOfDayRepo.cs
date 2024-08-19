using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.UnitTests.MockRepos
{
    public class MockTimeOfDayRepo : ITimeOfDayRepository
    {
        public DateTime CurrentTime => throw new NotImplementedException();

        public int? GetTimeOfDayID()
        {
            throw new NotImplementedException();
        }
    }
}
