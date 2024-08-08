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
            _dbContext.CafeOrder.Add(order);
            _dbContext.SaveChanges();
            return order.OrderID;
        }

        public void Delete(int orderID)
        {
            var order = _dbContext.CafeOrder.FirstOrDefault(o => o.OrderID == orderID);

            if (order != null)
            {
                _dbContext.CafeOrder.Remove(order);
                _dbContext.SaveChanges();
            }
        }

        public void Update(CafeOrder order)
        {
            _dbContext.CafeOrder.Update(order);
            _dbContext.SaveChanges();
        }

        public List<Server> GetActiveServers()
        {
            return _dbContext.Server
                .Where(s => s.TermDate == null || s.TermDate >= DateTime.Now)
                .ToList();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _dbContext.PaymentType.ToList();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return _dbContext.CafeOrder
                .Include(co => co.Server)
                .Include(co => co.OrderItems)
                .ThenInclude(oi => oi.ItemPrice)
                .ThenInclude(ip => ip.Item)
                .Where(co => co.PaymentTypeID == null)
                .ToList(); 
        }

        public CafeOrder GetOrderDetails(int orderID)
        {
            return _dbContext.CafeOrder
                .Include(o => o.OrderItems)
                .Where(o => o.OrderID == orderID)
                .First();
        }

        public CafeOrder? GetByOrderID(int orderID)
        {
            return _dbContext.CafeOrder
                .Where(o => o.OrderID == orderID)
                .FirstOrDefault();
        }
    }
}
