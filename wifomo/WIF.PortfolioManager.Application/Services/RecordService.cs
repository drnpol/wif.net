using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Contracts.Persistence;

namespace WIF.PortfolioManager.Application.Services
{
    public class RecordService: ServiceBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
