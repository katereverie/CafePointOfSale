using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        int Add(CafeOrder order); // return an new orderID
        void Update(CafeOrder order); // could be Payment, could be adding more items
        void Delete(int orderID); // delete CafeOrder && a list of its OrderItems
        CafeOrder? GetByOrderID(int orderID);
        CafeOrder GetOrderDetails(int orderID); // include a list of its OrderItems
        List<CafeOrder> GetOpenOrders(); // paymentTypeID null
        List<PaymentType> GetAllPaymentTypes();
        List<Server> GetActiveServers();
    }
}
