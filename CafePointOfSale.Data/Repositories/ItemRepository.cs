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

        public List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID)
        {
            if (timeOfDayID == null) 
            {
                return null;
            }
            
            var allItems = _dbContext.Item
                .Include(i => i.Category)
                .Include(i => i.ItemPrices)
                .ToList();

            var currentItems = new List<CurrentItem>();

            foreach (var item in allItems)
            {
                var currentItemPrice = item.ItemPrices.FirstOrDefault(ip => ip.TimeOfDayID == timeOfDayID && (ip.EndDate == null || ip.EndDate > DateTime.Now));
                if (currentItemPrice != null)
                {
                    currentItems.Add(new CurrentItem
                    {
                        ItemID = item.ItemID,
                        ItemName = item.ItemName,
                        ItemDescription = item.ItemDescription,
                        Category = item.Category,
                        ItemPrice = currentItemPrice
                    });
                }
            }

            return currentItems;
        }
    }
}
