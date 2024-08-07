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
        private ITimeOfDayRepository _timeOfDayRepo;

        public OrderService(IOrderRepository orderRepo, IItemRepository itemRepo, ITimeOfDayRepository timeOfDayRepo)
        {
            _orderRepo = orderRepo;
            _itemRepo = itemRepo;
            _timeOfDayRepo = timeOfDayRepo;
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
            try
            {
                _orderRepo.Delete(orderID);

                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result<int> CreateOrder(CafeOrder order)
        {
            try
            {
                int orderID = _orderRepo.Add(order);

                return ResultFactory.Success(orderID);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<int>(ex.Message);
            }
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

        public Result<List<Item>> GetAvailableItems(int categoryID)
        {
            try
            {
                int timeOfDayID = _timeOfDayRepo.GetTimeOfDayID();

                if (timeOfDayID == -1)
                {
                    return ResultFactory.Fail<List<Item>>("At the current time of day, there is no available item.");
                }
                else
                {
                    var itemList = _itemRepo.GetAvailableItems(categoryID, timeOfDayID);
                    return ResultFactory.Success(itemList);
                }
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

        public List<OrderItem> GetOrderSummary(List<OrderItem> itemList)
        {
            int totalQuantity = 0;

            foreach (var item in itemList)
            {

                totalQuantity += item.Quantity;
            }
        }

        public Result<List<PaymentType>> GetPaymentTypes()
        {
            try
            {
                var paymentTypeList = _orderRepo.GetAllPaymentTypes();

                return ResultFactory.Success(paymentTypeList);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<PaymentType>>(ex.Message);
            }
        }
    }
}
