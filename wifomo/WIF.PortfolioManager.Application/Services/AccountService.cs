using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Contracts.Persistence;
using WIF.PortfolioManager.Domain.Models;
namespace WIF.PortfolioManager.Application.Services
{
    public class AccountService : ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
