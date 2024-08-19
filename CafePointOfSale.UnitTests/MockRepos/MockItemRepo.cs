using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.UnitTests.MockRepos
{
    public class MockItemRepo : IItemRepository
    {
        public List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID)
        {
            throw new NotImplementedException();
        }
    }
}
