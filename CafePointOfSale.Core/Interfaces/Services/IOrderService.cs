using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Result<int> CreateOrder(CafeOrder order); // return an new orderID
        Result ProcessOrder(CafeOrder order);
        Result AddPaymentMethod(int paymentOptionID);
        Result CancelOrder(int orderID); // delete CafeOrder && a list of its OrderItems
        Result<List<Server>> GetActiveServers();
        Result<List<PaymentType>> GetPaymentTypes();
        Result<List<Category>> GetAvailableCategories();
        Result<List<AvailableItem>> GetAvailableItems(int categoryID);
        Result<List<CafeOrder>> GetOpenOrders();
        CafeOrder CalculateSubtotalAndTax(CafeOrder order);
    }
}
