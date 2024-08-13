using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface IItemRepository
    {
        List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID); // based on time of the day
    }
}
