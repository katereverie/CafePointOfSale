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
                MenuPrinter.DisplayMainMenu();

                int option = IO.GetInteger("Enter Menu Option: ");
                switch (option)
                {
                    case 1:
                        ManageOrders();
                        break;
                    case 2:
                        ManagePayment();
                        break;
                    case 3:
                        ViewReports();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        IO.AnyKey();
                        continue;
                }
            } while (true);
        }

        private void ManageOrders()
        {
            do
            {
                Console.Clear();
                MenuPrinter.DisplayOrderMenu();

                int option = IO.GetInteger("Enter Management Option: ");
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
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        IO.AnyKey();
                        continue;
                }

            } while (true);
        }

        private void ManagePayment()
        {
            do
            {
                Console.Clear();
                MenuPrinter.DisplayPaymentMenu();

                int option = IO.GetInteger("Enter Management Option: ");
                switch (option)
                {
                    case 1:
                        OrderWorkflows.ProcessPayment(_serviceFactory.CreateOrderService());
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        IO.AnyKey();
                        continue;

                }
            } while (true);
        }

        private void ViewReports()
        {
            do
            {
                Console.Clear();
                MenuPrinter.DisplayReportMenu();

                int option = IO.GetInteger("Enter Option: ");
                switch (option)
                {
                    case 1:
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        IO.AnyKey();
                        continue;
                }
            } while (true);
        }
    }
}
