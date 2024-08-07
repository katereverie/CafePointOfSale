using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Result<int> CreateOrder(CafeOrder order); // return an new orderID
        Result AddToOrder(List<OrderItem> items);
        Result AddPaymentMethod(int paymentOptionID);
        Result CancelOrder(int orderID); // delete CafeOrder && a list of its OrderItems
        Result<List<Server>> GetActiveServers();
        Result<List<PaymentType>> GetPaymentTypes();
        Result<List<Category>> GetAvailableCategories();
        Result<List<Item>> GetAvailableItems(int categoryID, int timeOfDayID);
        Result<List<CafeOrder>> GetOpenOrders();
    }
}
