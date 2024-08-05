using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void AddPaymentMethod(int paymentOptionID)
        {
            throw new NotImplementedException();
        }

        public void AddToOrder(List<OrderItem> items)
        {
            throw new NotImplementedException();
        }

        public void CancelOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public int CreateOrder(int serverID)
        {
            throw new NotImplementedException();
        }

        public List<Server> GetActiveServers()
        {
            throw new NotImplementedException();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            throw new NotImplementedException();
        }

        public CafeOrder GetOrderDetails(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<PaymentType> GetPaymentTypes()
        {
            throw new NotImplementedException();
        }
    }
}
