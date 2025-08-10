using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Contracts.Persistence;

namespace WIF.PortfolioManager.Application.Services
{
    public class ServiceBase
    {
        protected readonly IUnitOfWork unitOfWork;
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
