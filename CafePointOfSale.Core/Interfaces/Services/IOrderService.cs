using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Result<int> CreateOrder(CafeOrder order);
        Result ProcessOrder(CafeOrder order);
        Result AddPaymentMethod(CafeOrder order, int paymentOptionID);
        Result CancelOrder(int orderID);
        Result<List<Server>> GetActiveServers();
        Result<List<PaymentType>> GetPaymentTypes();
        Result<List<CurrentItem>> GetAllCurrentItems();
        Result<List<CafeOrder>> GetOpenOrders();
        CafeOrder CalculateSubtotalAndTax(CafeOrder order);
    }
}
