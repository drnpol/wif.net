using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        Task SaveChanges();
    }
}
