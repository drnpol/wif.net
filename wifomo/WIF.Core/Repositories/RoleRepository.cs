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
    public class RoleRepository : RepositoryBase<int, Role>
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // do somethign here...
        }
        public Task<List<Role>> GetMany()
        {
            //return base.db.Roles.ToListAsync();
            return null;
        }
        public Task<Role> GetOne(RoleEnum role)
        {
            //return base.db.Roles.FirstOrDefaultAsync(x => x.Enum == role);
            return null;
        }
    }
}
