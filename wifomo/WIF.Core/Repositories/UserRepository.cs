using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WIF.Core.Data;
using WIF.Core.Enums;
using WIF.Core.Models;

namespace WIF.Core.Repositories
{
    public class UserRepository : RepositoryBase<Guid, User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // do something here...
        }

        public Task<User> GetOne(string id)
        {
            //return base.db.Users.FirstOrDefaultAsync(x => x.Id == id);
            return null;
        }
        public Task<User?> GetOneByMail(string email)
        {
            //return base.db.Users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
            return null;
        }
        public async Task<List<User>> GetMany(RoleEnum role)
        {
            //return await base.db.Users.Include(x => x.Roles).Where(x => x.Roles.Any(x => x.Enum == role)).ToListAsync();
            return null;
        }
        public Task<List<User>> GetMany()
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
