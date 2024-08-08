using CafePointOfSale.Core.Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace CafePointOfSale.Data
{
    public class CafeContext : DbContext
    {
        private string _connectionString;

        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPrice> ItemPrice { get; set; }
        public DbSet<TimeOfDay> TimeOfDay { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<CafeOrder> CafeOrder { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }    
        public DbSet<Server> Server { get; set; }

        public CafeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
