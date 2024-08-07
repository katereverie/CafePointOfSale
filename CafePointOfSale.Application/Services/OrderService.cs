using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;
using CafePointOfSale.Core.Interfaces.Services;

namespace CafePointOfSale.Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepo;
        private IItemRepository _itemRepo;

        public OrderService(IOrderRepository orderRepo, IItemRepository itemRepo)
        {
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;
        }

        public Result AddPaymentMethod(int paymentOptionID)
        {
            throw new NotImplementedException();
        }

        public Result AddToOrder(List<OrderItem> items)
        {
            throw new NotImplementedException();
        }

        public Result CancelOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public Result<int> CreateOrder(CafeOrder order)
        {
            throw new NotImplementedException();
        }

        public Result<List<Server>> GetActiveServers()
        {
            try
            {
                var serverList = _orderRepo.GetActiveServers();

                return ResultFactory.Success(serverList);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Server>>(ex.Message);
            }
        }

        public Result<List<Category>> GetAvailableCategories()
        {
            try
            {
                var categoryList = _itemRepo.GetAvailableCategories();

                return ResultFactory.Success(categoryList);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Category>>(ex.Message);
            }
        }

        public Result<List<Item>> GetAvailableItems(int categoryID, int timeOfDayID)
        {
            try
            {
                var itemList = _itemRepo.GetAvailableItems(categoryID, timeOfDayID);

                return ResultFactory.Success(itemList);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Item>>(ex.Message);
            }
        }

        public Result<List<CafeOrder>> GetOpenOrders()
        {
            try
            {
                var orderList = _orderRepo.GetOpenOrders();

                return ResultFactory.Success(orderList);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<CafeOrder>>(ex.Message);
            }
        }

        public Result<List<PaymentType>> GetPaymentTypes()
        {
            throw new NotImplementedException();
        }
    }
}
