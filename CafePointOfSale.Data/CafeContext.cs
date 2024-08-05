using CafePointOfSale.Core.Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace CafePointOfSale.Data
{
    public class CafeContext : DbContext
    {
        private string _connectionString;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public DbSet<TimeOfDay> TimeOfDays { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CafeOrder> CafeOrders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }    
        public DbSet<Server> Servers { get; set; }

        public CafeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
