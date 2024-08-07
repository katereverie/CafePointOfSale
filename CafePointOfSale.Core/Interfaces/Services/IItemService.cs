using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IItemService
    {
        Result<List<Category>> GetAvailableCategories();
        Result<List<Item>> GetAvailableItems();
    }
}
