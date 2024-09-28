using CafePointOfSale.Application;
using CafePointOfSale.Core.Interfaces.AppConfiguration;
using CafePointOfSale.UI.Utilities;
using CafePointOfSale.UI.Workflows;

namespace CafePointOfSale.UI
{
    public class App
    {
        IAppConfiguration _config;
        ServiceFactory _serviceFactory;

        public App()
        {
            _config = new AppConfiguration();
            _serviceFactory = new ServiceFactory(_config);
        }

        public void Run()
        {
            do
            {
                Console.Clear();
                MenuHelper.DisplayMainMenu();

                int option = InputHelper.GetInteger("Enter Menu Option: ");
                switch (option)
                {
                    case 1:
                        ManageOrders();
                        break;
                    case 2:
                        ViewReports();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        InputHelper.AnyKey();
                        continue;
                }
            } while (true);
        }

        private void ManageOrders()
        {
            do
            {
                Console.Clear();
                MenuHelper.DisplayOrderMenu();

                int option = InputHelper.GetInteger("Enter Option: ");
                switch (option)
                {
                    case 1:
                        OrderWorkflows.CreateOrder(_serviceFactory.CreateOrderService());
                        break;
                    case 2:
                        OrderWorkflows.AddItemsToOrder(_serviceFactory.CreateOrderService());
                        break;
                    case 3:
                        OrderWorkflows.ViewOpenOrders(_serviceFactory.CreateOrderService());
                        break;
                    case 4:
                        OrderWorkflows.CancelOrder(_serviceFactory.CreateOrderService());
                        break;
                    case 5:
                        OrderWorkflows.ProcessPayment(_serviceFactory.CreateOrderService());
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        InputHelper.AnyKey();
                        continue;
                }

            } while (true);
        }

        private void ViewReports()
        {
            do
            {
                Console.Clear();
                MenuHelper.DisplayReportMenu();

                int option = InputHelper.GetInteger("Enter Option: ");
                switch (option)
                {
                    case 1:
                        ReportWorkflows.GetDailySalesReport(_serviceFactory.CreateReportService());
                        break;
                    case 2:
                        Console.WriteLine("Yet to be implemented");
                        InputHelper.AnyKey();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        InputHelper.AnyKey();
                        continue;
                }
            } while (true);
        }
    }
}
