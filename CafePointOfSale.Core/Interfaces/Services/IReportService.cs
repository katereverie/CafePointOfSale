using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;

namespace CafePointOfSale.Core.Interfaces.Services
{
    public interface IReportService
    {
        Result<List<CafeOrder>> GetCafeOrdersByDate(DateOnly date);
    }
}