using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.Core.Repositories;

namespace WIF.Core.Services
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
