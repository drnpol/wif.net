using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WIF.PortfolioManager.Domain.Enums;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Identity.Models;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<Guid, ApplicationUser>
    {
        public UserRepository(ApplicationPersistenceDbContext dbContext) : base(dbContext)
        {
            // do something here...
        }

        public Task<ApplicationUser> GetOne(string id)
        {
            //return base.db.Users.FirstOrDefaultAsync(x => x.Id == id);
            return null;
        }
        public Task<ApplicationUser?> GetOneByMail(string email)
        {
            //return base.db.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
            return null;
        }
        public async Task<List<ApplicationUser>> GetMany(RoleEnum role)
        {
            //return await base.db.Users.Include(x => x.Roles).Where(x => x.Roles.Any(x => x.Enum == role)).ToListAsync();
            return null;
        }
        public Task<List<ApplicationUser>> GetMany()
        {
            //return base.db.Users.Include(x => x.Roles).ToListAsync();
            return null;
        }

        public Task<bool> IsInRole(string userId, RoleEnum role)
        {
            //return base.db.Users.Include(x => x.Roles).AnyAsync(x => x.Id == userId && x.Roles.Any(x => x.Enum == role));
            return null;
        }
    }
}
