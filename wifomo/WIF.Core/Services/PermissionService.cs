using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Persistence.Repositories;

namespace WIF.PortfolioManager.Application.Services
{
    public class PermissionService: ServiceBase
    {
        private readonly AppSettings _appSettings;
        private readonly UnitOfWork _unitOfWork;
        public PermissionService(
            AppSettings appSettings,
            UnitOfWork unitOfWork
            ) : base(unitOfWork)
        {
            _appSettings = appSettings;
            _unitOfWork = unitOfWork;
        }
    }
}
