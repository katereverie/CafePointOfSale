using CafePointOfSale.Core.Entities.DTOs;
using CafePointOfSale.Core.Entities.Tables;
using CafePointOfSale.Core.Interfaces.Services;

namespace CafePointOfSale.Application.Services
{
    public class ReportService : IReportService
    {
        public Result<List<CafeOrder>> GetCafeOrdersByDate(DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}