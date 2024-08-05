using CafePointOfSale.Core.Entities.Enums;

namespace CafePointOfSale.Core.Interfaces.AppConfiguration
{
    public interface IAppConfiguration
    {
        string GetConnectionString();
        DatabaseMode GetDatabaseMode();
    }
}
