using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePointOfSale.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CafeContext _dbContext;

        public OrderRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public int Add(CafeOrder order)
        {
            _dbContext.CafeOrders.Add(order);
            _dbContext.SaveChanges();
            return order.OrderID;
        }

        public void Delete(int orderID)
        {
            var order = _dbContext.CafeOrders.FirstOrDefault(o => o.OrderID == orderID);

            if (order != null)
            {
                _dbContext.CafeOrders.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public void Update(CafeOrder order)
        {
            _dbContext.CafeOrders.Update(order);
            _dbContext.SaveChanges();
        }

        public List<Server> GetActiveServers()
        {
            return _dbContext.Servers.ToList();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _dbContext.PaymentTypes.ToList();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return _dbContext.CafeOrders
                .Where(o => o.PaymentTypeID == null)
                .ToList(); 
        }

        public CafeOrder GetOrderDetails(int orderID)
        {
            return _dbContext.CafeOrders
                .Include(o => o.OrderItems)
                .Where(o => o.OrderID == orderID)
                .First();
        }

        public CafeOrder? GetByOrderID(int orderID)
        {
            return _dbContext.CafeOrders
                .Where(o => o.OrderID == orderID)
                .FirstOrDefault();
        }
    }
}
