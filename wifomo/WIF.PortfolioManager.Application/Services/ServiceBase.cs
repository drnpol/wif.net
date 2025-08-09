using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Persistence;
using WIF.PortfolioManager.Persistence.Repositories;

namespace WIF.PortfolioManager.Application.Services
{
    public class ServiceBase
    {
        protected readonly UnitOfWork unitOfWork;
        public ServiceBase( UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
