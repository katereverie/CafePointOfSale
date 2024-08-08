using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePointOfSale.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private CafeContext _dbContext;

        public ItemRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public List<Category> GetAvailableCategories()
        {
            return _dbContext.Category.ToList();
        }

        public List<AvailableItem> GetAvailableItems(int categoryID, int timeOfDayID)
        {
            var items = _dbContext.Item
                .Include(i => i.Category)
                .Include(i => i.ItemPrices)
                .Where(i => i.CategoryID == categoryID)
                .ToList();

            var availableItems = new List<AvailableItem>();

            foreach (var item in items)
            {
                var currentItemPrice = item.ItemPrices.FirstOrDefault(ip => ip.TimeOfDayID == timeOfDayID && (ip.EndDate == null || ip.EndDate > DateTime.Now));
                if (currentItemPrice != null)
                {
                    availableItems.Add(new AvailableItem
                    {
                        ItemID = item.ItemID,
                        ItemName = item.ItemName,
                        ItemDescription = item.ItemDescription,
                        ItemPrice = currentItemPrice
                    });
                }
            }

            return availableItems;
        }
    }
}
