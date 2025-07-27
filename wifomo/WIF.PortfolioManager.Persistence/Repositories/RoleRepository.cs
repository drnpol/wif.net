using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WIF.PortfolioManager.Persistence;
using WIF.PortfolioManager.Identity.Models;
using WIF.PortfolioManager.Domain.Enums;
using WIF.PortfolioManager.Domain.Models;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public class RoleRepository : RepositoryBase<int, ApplicationRole>
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // do somethign here...
        }
        public Task<List<ApplicationRole>> GetMany()
        {
            //return base.db.Roles.ToListAsync();
            return null;
        }
        public Task<ApplicationRole> GetOne(RoleEnum role)
        {
            //return base.db.Roles.FirstOrDefaultAsync(x => x.Enum == role);
            return null;
        }
    }
}
