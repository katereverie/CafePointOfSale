using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Repositories;

namespace CafePointOfSale.UnitTests.MockRepos
{
    public class MockCafeRepo : ICafeRepository
    {
        private List<CafeOrder> _cafeOrders = new List<CafeOrder>
        {
            new CafeOrder
            {
                OrderID = 1,
                ServerID = 1,
                PaymentTypeID = null,
                OrderDate = DateTime.Now,
                SubTotal = 0,
                Tax = 0,
                Tip = 0,
                AmountDue = 0,

                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        OrderItemID = 1,
                        OrderID = 1,
                        ItemPriceID = 1,
                        Quantity = 1,
                        ExtendedPrice = 5.0m,

                        ItemPrice = new ItemPrice
                        {
                            ItemPriceID = 1,
                            ItemID = 1,
                            TimeOfDayID = 2,
                            Price = 5.0m,
                            StartDate = new DateTime(2024, 1, 1),
                            EndDate = null
                        }
                    },
                    new OrderItem
                    {
                        OrderItemID = 2,
                        OrderID = 2,
                        ItemPriceID = 2,
                        Quantity = 2,
                        ExtendedPrice = 6.0m,

                        ItemPrice = new ItemPrice
                        {
                            ItemPriceID = 2,
                            ItemID = 2,
                            TimeOfDayID = 2,
                            Price = 3.0m,
                            StartDate = new DateTime(2024, 1, 1),
                            EndDate = null
                        }
                    }
                }
            },
            new CafeOrder
            {
                OrderID = 2,
                ServerID = 2,
                PaymentTypeID = null,
                OrderDate = DateTime.Now,
                SubTotal = 0,
                Tax = 0,
                Tip = 0,
                AmountDue = 0,

                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        OrderItemID = 1,
                        OrderID = 1,
                        ItemPriceID = 1,
                        Quantity = 15,
                        ExtendedPrice = 75.0m,

                        ItemPrice = new ItemPrice
                        {
                            ItemPriceID = 1,
                            ItemID = 1,
                            TimeOfDayID = 2,
                            Price = 5.0m,
                            StartDate = new DateTime(2024, 1, 1),
                            EndDate = null
                        }
                    },
                    new OrderItem
                    {
                        OrderItemID = 2,
                        OrderID = 2,
                        ItemPriceID = 2,
                        Quantity = 2,
                        ExtendedPrice = 6.0m,

                        ItemPrice = new ItemPrice
                        {
                            ItemPriceID = 2,
                            ItemID = 2,
                            TimeOfDayID = 2,
                            Price = 3.0m,
                            StartDate = new DateTime(2024, 1, 1),
                            EndDate = null
                        }
                    }
                }
            }
        };
        private List<OrderItem> _orderItems = new List<OrderItem>();
        public int Add(CafeOrder order)
        {
            _cafeOrders.Add(order);
            return _cafeOrders.Last().OrderID;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int orderID)
        {
            var order = _cafeOrders.FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.OrderItems.Clear();
                _cafeOrders.Remove(order);
            }
        }

        public List<Server> GetActiveServers()
        {
            throw new NotImplementedException();
        }

        public List<CurrentItem>? GetAllCurrentItems(int? timeOfDayID)
        {
            throw new NotImplementedException();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            throw new NotImplementedException();
        }

        public CafeOrder? GetByOrderID(int orderID)
        {
            return _cafeOrders.SingleOrDefault(o => o.OrderID == orderID);
        }

        public DailySalesSummary? GetDailySalesSummary(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return _cafeOrders.Where(o => o.PaymentTypeID == null).ToList();
        }

        public CafeOrder GetOrderDetails(int orderID)
        {
            throw new NotImplementedException();
        }

        public void Update(CafeOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
