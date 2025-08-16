using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Contracts.Identity;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepositoryBase<string, IApplicationUser<string>>
    {
        Task<IApplicationUser<string>> GetUser(IApplicationUser<string> user);
        Task<IApplicationUser<string>> GetUserByEmail(string email);
    }
}
