using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.Extensions;
using WIF.PortfolioManager.Application.Extensions.Models;
using WIF.PortfolioManager.Application.Features.Kendo.Requests;
using WIF.PortfolioManager.Application.DTOs.BBWalletImport;
using WIF.PortfolioManager.Persistence.Repositories;
using WIF.PortfolioManager.Domain.Models;
using WIF.PortfolioManager.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WIF.PortfolioManager.Application.Services
{

    public class BBWalletImportService : ServiceBase
    {
        private readonly AppSettings _appSettings;
        private readonly UnitOfWork _unitOfWork;
        public BBWalletImportService(
            AppSettings appSettings,
            UnitOfWork unitOfWork
            ) : base(unitOfWork)
        {
            _appSettings = appSettings;
            _unitOfWork = unitOfWork;
        }
        public Task<List<BBWalletImport>> GetMany(KendoListRequest kendoListRequest)
        {
            List<BBWalletImport> result;
            try
            {
                var queryable = this._unitOfWork.BBWalletImportRepository.DbContext.BBWalletImports
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
                return this._unitOfWork.BBWalletImportRepository.DbContext.BBWalletImports.ApplyFilters(kendoListRequest.Filter).CountAsync();
            }
            catch (Exception ex)
            {
                // log the exception
                throw ex;
            }
        }

        public async Task<KendoListResponse<BBWalletImportListDto>> GetBBWalletImportRecords(string kendoListRequestString)
        {
            var kendoListHelper = new KendoListHelper<BBWalletImportListDto>();
            var kendoListRequest = kendoListHelper.GetKendoListRequest(kendoListRequestString);

            
            List<BBWalletImportListDto> records = new List<BBWalletImportListDto>();

            // TODO - Fetch all records with Kendo filter
            var result = await this.GetBBWalletImportRecords(kendoListRequest); // overload
            int total = await this.GetTotalCount(kendoListRequest);
            // TODO - Transform fetched records to Dto
            foreach (var item in result)
            {
                // do other transformation here...
                records.Add(item.Map());
            }

            
            var response = kendoListHelper.GetKendoListResponse(records, total);
            return response;
        }
        public async Task<List<BBWalletImport>> GetBBWalletImportRecords(KendoListRequest kendoListRequest)
        {
            //var where = "WHERE 1=1";
            //return await this.ExecuteSQLQuery(
            //    $"SELECT * FROM dbo.budgetbaker_wallet_import " +
            //    $"{where} " +
            //    $"ORDER BY date DESC " +
            //    $"OFFSET {kendoListRequest.Paging.Skip} ROWS " +
            //    $"FETCH NEXT {kendoListRequest.Paging.Take} " +
            //    $"ROWS ONLY"
            //);
            return await this.GetMany(kendoListRequest);
        }
        public async Task<int> GetTotalCount()
        {
            return await _unitOfWork.BBWalletImportRepository.Count();
        }
        public async Task<int> GetTotalCount(KendoListRequest kendoListRequest)
        {
            return await this.Count(kendoListRequest);
        }
        public Task<int> GetTotalCount(ClaimsPrincipal identity)
        {
            return null;
        }
    }
}
