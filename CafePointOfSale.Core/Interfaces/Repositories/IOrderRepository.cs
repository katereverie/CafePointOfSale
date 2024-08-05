using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        int CreateOrder(int serverID); // return an new orderID
        void AddToOrder(List<OrderItem> items);
        void CancelOrder(int orderID); // delete CafeOrder && a list of its OrderItems
        void AddPaymentMethod(int paymentOptionID);
        CafeOrder GetOrderDetails(int orderID); // include a list of its OrderItems
        List<Server> GetActiveServers(); 
        List<PaymentType> GetPaymentTypes();
        List<CafeOrder> GetOpenOrders(); // paymentTypeID unassigned
    }
}
