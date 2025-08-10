using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Application.Contracts.Persistence
{
    public interface IAccountRepository : IRepositoryBase<Guid, Account>
    {
    }
}
