using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIF.Core.DTOs.BBWalletImport;
using WIF.Core.Extensions.Mapper;
using WIF.Core.Features.Kendo.Requests;
using WIF.Core.Models;
using WIF.Core.Repositories;

namespace WIF.Core.Services
{

    public class BBWalletImportService : ServiceBase
    {
        private readonly UnitOfWork _unitOfWork;
        public BBWalletImportService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<KendoListResponse<BBWalletImportListDto>> GetBBWalletImportRecords(string kendoListRequestString, bool includeTransfers = false)
        {
            var kendoListHelper = new KendoListHelper<BBWalletImportListDto>();
            var kendoListRequest = kendoListHelper.GetKendoListRequest(kendoListRequestString);

            int total = 0;
            List<BBWalletImportListDto> allRecords = new List<BBWalletImportListDto>();

            // TODO - Fetch all records with Kendo filter
            var result = await _unitOfWork.BBWalletImportRepository.GetMany();
            // TODO - Transform fetched records to Dto
            foreach(var item in result)
            {
                // do other transformation here...
                allRecords.Add(item.map());
                total++;
            }

            var response = kendoListHelper.GetKendoListResponse(allRecords, total);
            return response;
        }
    }
}
