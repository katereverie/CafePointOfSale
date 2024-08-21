using CafePointOfSale.Application.Services;
using CafePointOfSale.UnitTests.MockRepos;using NUnit.Framework;

namespace CafePointOfSale.UnitTests
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void OrderTotals_LessThan15OrderItems()
        {
            var service = new OrderService(new MockCafeRepo(), new MockTimeOfDayRepo());
            var orders = service.GetOpenOrders().Data;

            var calculatedOrder = service.CalculateOrderTotals(orders.Find(o => o.OrderID == 1));

            Assert.That(calculatedOrder.SubTotal, Is.EqualTo(11m));
            Assert.That(calculatedOrder.Tax, Is.EqualTo(0.88m));
            Assert.That(calculatedOrder.Tip, Is.EqualTo(0));
            Assert.That(calculatedOrder.AmountDue, Is.EqualTo(11.88m));
        }

        [Test]
        public void OrderTotals_MoreThan15OrderItems()
        {
            var service = new OrderService(new MockCafeRepo(), new MockTimeOfDayRepo());
            var orders = service.GetOpenOrders().Data;

            var calculatedOrder = service.CalculateOrderTotals(orders.Find(o => o.OrderID == 2));

            Assert.That(calculatedOrder.SubTotal, Is.EqualTo(81m));
            Assert.That(calculatedOrder.Tax, Is.EqualTo(6.48m));
            Assert.That(calculatedOrder.Tip, Is.EqualTo(12.15m));
            Assert.That(calculatedOrder.AmountDue, Is.EqualTo(99.63m));
        }

        [Test]
        public void Test_CancelOrder_ClosedOrder()
        {
            // Since users are only allowed to choose open orders to cancel, we compare if a closed order will appear in the GetOpenOrders()'s return result.
            var service = new OrderService(new MockCafeRepo(), new MockTimeOfDayRepo());
            var openOrdersList1 = service.GetOpenOrders().Data;
            var order1 = openOrdersList1.Find(o => o.OrderID == 1);
            service.AddPaymentMethod(order1, 2); // closing order1 (with ID 1)
            var openOrdersList2 = service.GetOpenOrders().Data;
            var order2 = openOrdersList2.FirstOrDefault(o => o.OrderID == 1);

            Assert.That(order2, Is.Null);
        }
    }
}
