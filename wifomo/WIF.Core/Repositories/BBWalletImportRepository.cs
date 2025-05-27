using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WIF.Core.Data;
using WIF.Core.Extensions;
using WIF.Core.Extensions.Models;
using WIF.Core.Features.Kendo.Requests;
using WIF.Core.Models;
using WIF.Core.Helpers;
using System.Linq.Expressions;

namespace WIF.Core.Repositories
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
        public Task<List<BBWalletImport>> GetMany(KendoListRequest kendoListRequest)
        {
            List<BBWalletImport> result;
            try
            {
                var queryable = base.db.BBWalletImports
                    .Skip(kendoListRequest.Paging.Skip)
                    .Take(kendoListRequest.Paging.Take);


                queryable = queryable.ApplyFilters(kendoListRequest.Filter);
                queryable = queryable.OrderByDescending(x => x.Date);

                return queryable.ToListAsync();
            }
            catch (Exception ex)
            {
                // log the exception
                throw ex;
            }
        }
        public Task<int> Count(KendoListRequest kendoListRequest)
        {
            try
            {
                return base.db.BBWalletImports.ApplyFilters(kendoListRequest.Filter).CountAsync();
            }
            catch (Exception ex)
            {
                // log the exception
                throw ex;
            }
        }
    }
}
