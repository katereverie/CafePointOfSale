using CafePointOfSale.Core.Entities.Enums;
using CafePointOfSale.Core.Interfaces.AppConfiguration;
using Microsoft.Extensions.Configuration;

namespace CafePointOfSale.UI
{
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _config;

        public AppConfiguration()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddUserSecrets<Program>()
                .Build();
        }

        public string GetConnectionString()
        {
            return _config["CafeDb"] ?? "";
        }

        public DatabaseMode GetDatabaseMode()
        {
            switch (_config["DatabaseMode"])
            {
                case "ORM":
                    return DatabaseMode.ORM;
                case "Training":
                    return DatabaseMode.Training;
                default:
                    throw new Exception("DabaseMode configuration key is missing.");
            }
        }
    }
}
