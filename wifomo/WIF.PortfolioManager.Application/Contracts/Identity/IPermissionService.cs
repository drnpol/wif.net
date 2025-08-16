using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Application.Contracts.Identity
{
    public interface IPermissionService<TUser>
    {
        Task<bool> UserCanCreateAccount(TUser user, Account account);
        Task<bool> UserCanUpdateAccount(TUser user, Account account);
        Task<bool> UserCanDeleteAccount(TUser user, Account account);
    }
}
