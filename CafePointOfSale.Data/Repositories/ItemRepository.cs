﻿using CafePointOfSale.Core.Entities.Tables;
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
            return _dbContext.Categories.ToList();
        }

        public List<Item> GetAvailableItems(int categoryID, int timeOfDayID)
        {
            return _dbContext.Items
                .Include(i => i.Category)
                .Include(i => i.ItemPrices)
                .Where(i => i.CategoryID == categoryID // item with matching category
                    && i.ItemPrices.Any(ip => ip.EndDate == null) // active item
                    && i.ItemPrices.Any(ip => ip.TimeOfDayID == timeOfDayID)) // item with price that matches time of the day
                .ToList();
        }
    }
}
