using CafePointOfSale.Core.Interfaces.AppConfiguration;

namespace CafePointOfSale.UI
{
    public class App
    {
        IAppConfiguration _config;

        public App()
        {
            _config = new AppConfiguration();
        }

        public void Run()
        {

        }
    }
}
