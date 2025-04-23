using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.Core.Repositories;

namespace WIF.Core.Services
{
    public class ServiceBase
    {
        protected readonly UnitOfWork unitOfWork;
        public ServiceBase(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
