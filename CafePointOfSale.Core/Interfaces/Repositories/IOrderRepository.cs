using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        int Add(CafeOrder order); 
        void Update(CafeOrder order); 
        void Delete(int orderID); 
        CafeOrder? GetByOrderID(int orderID);
        CafeOrder GetOrderDetails(int orderID); 
        List<CafeOrder> GetOpenOrders(); 
        List<CafeOrder> GetOrdersByDate(DateTime date);
        List<PaymentType> GetAllPaymentTypes();
        List<Server> GetActiveServers();
    }
}
