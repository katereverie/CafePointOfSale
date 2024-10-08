﻿using CafePointOfSale.Application.Services;
using CafePointOfSale.Core.Entities.Enums;
using CafePointOfSale.Core.Interfaces.AppConfiguration;
using CafePointOfSale.Core.Interfaces.Services;
using CafePointOfSale.Data.Repositories;

namespace CafePointOfSale.Application
{
    public class ServiceFactory
    {
        private IAppConfiguration _config;

        public ServiceFactory(IAppConfiguration config)
        {
            _config = config;
        }

        public IOrderService CreateOrderService()
        {
            switch (_config.GetDatabaseMode())
            {
                case DatabaseMode.ORM:
                    return new OrderService(
                        new CafeRepository(_config.GetConnectionString()),
                        new TimeOfDayRepository(_config.GetConnectionString()));
                case DatabaseMode.Mock:
                default:
                    throw new NotImplementedException();
            }
        }

        public IReportService CreateReportService() 
        {
            switch (_config.GetDatabaseMode()) 
            {
                case DatabaseMode.ORM:
                    return new ReportService(new CafeRepository(_config.GetConnectionString()));
                case DatabaseMode.Mock:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
