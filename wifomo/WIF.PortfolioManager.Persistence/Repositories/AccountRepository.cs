using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public class AccountRepository : RepositoryBase<Guid, Account>
    {
        public AccountRepository(ApplicationPersistenceDbContext dbContext) : base(dbContext)
        {

        }
    }
}
