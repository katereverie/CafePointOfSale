using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface ICafeRepository
    {
        int Add(CafeOrder order);
        void AddOrderItem(OrderItem orderItem);
        void Update(CafeOrder order); 
        void Delete(int orderID); 
        CafeOrder? GetByOrderID(int orderID);
        CafeOrder GetOrderDetails(int orderID); 
        List<CafeOrder> GetOpenOrders(); 
        DailySalesSummary? GetDailySalesSummary(DateTime date);
        List<PaymentType> GetAllPaymentTypes();
        List<Server> GetActiveServers();
        List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID);
    }
}
