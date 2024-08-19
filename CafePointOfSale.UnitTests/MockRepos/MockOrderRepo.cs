using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.UnitTests.MockRepos
{
    public class MockOrderRepo : ICafeRepository
    {
        public int Add(CafeOrder order)
        {
            throw new NotImplementedException();
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Server> GetActiveServers()
        {
            throw new NotImplementedException();
        }

        public List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID)
        {
            throw new NotImplementedException();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            throw new NotImplementedException();
        }

        public CafeOrder? GetByOrderID(int orderID)
        {
            throw new NotImplementedException();
        }

        public DailySalesSummary? GetDailySalesSummary(DateTime date)
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

        public void Update(CafeOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
