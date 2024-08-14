using CafePointOfSale.Core.Entities.DTOs;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface IItemRepository
    {
        List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID);
    }
}
