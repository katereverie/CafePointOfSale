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

        public Result AddPaymentMethod(CafeOrder order, int paymentOptionID)
        {
            try
            {
                order.PaymentTypeID = paymentOptionID;
                _orderRepo.Update(order);

                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result ProcessOrder(CafeOrder order)
        {
            try
            {
                int itemCount = 0;

                foreach (var item in order.OrderItems)
                {
                    itemCount += item.Quantity;
                }

                order.Tip = order.Tip ?? 0;
                order.AmountDue = order.AmountDue ?? 0;

                if (itemCount > 15)
                {
                    order.Tip = order.SubTotal * 0.15m;
                }

                order.AmountDue = order.SubTotal + order.Tax + order.Tip;
                
                _orderRepo.Update(order);

                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
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

        public Result<List<CurrentItem>> GetAllCurrentItems()
        {
            try
            {
                int timeOfDayID = _timeOfDayRepo.GetTimeOfDayID();

                if (timeOfDayID == -1)
                {
                    return ResultFactory.Fail<List<CurrentItem>>("At the current time of day, there is no available item.");
                }
                else
                {
                    var itemList = _itemRepo.GetAllCurrentItems(timeOfDayID);
                    return ResultFactory.Success(itemList);
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<CurrentItem>>(ex.Message);
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

        public CafeOrder CalculateSubtotalAndTax(CafeOrder order)
        {
            order.SubTotal = order.SubTotal ?? 0;
            order.Tax = order.Tax ?? 0;

            foreach (var item in order.OrderItems)
            {
                order.SubTotal += item.ExtendedPrice;
            }

            order.Tax = order.SubTotal * 0.08m;

            return order;
        }
    }
}
