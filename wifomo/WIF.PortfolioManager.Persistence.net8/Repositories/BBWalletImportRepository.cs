using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Application.Features.Kendo.Requests;
using WIF.PortfolioManager.Application.Helpers;

namespace WIF.PortfolioManager.Persistence.Repositories
{
    public class BBWalletImportRepository : RepositoryBase<Guid, BBWalletImport>
    {
        public BBWalletImportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            // do something here...
        }
        public Task<BBWalletImport> GetOne(int id)
        {
            return base.db.BBWalletImports.FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<List<BBWalletImport>> GetMany()
        {
            List<BBWalletImport> result;
            try
            {
                return base.db.BBWalletImports
                    .Take(1000)
                    .ToListAsync();
            }catch(Exception ex)
            {
                // log the exception
                throw ex;
            }
        }
    }
}
