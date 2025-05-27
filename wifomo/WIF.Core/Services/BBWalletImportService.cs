using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using WIF.Core.DTOs.BBWalletImport;
using WIF.Core.Extensions.Models;
using WIF.Core.Features.Kendo.Requests;
using WIF.Core.Models;
using WIF.Core.Repositories;

namespace WIF.Core.Services
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
            return await _unitOfWork.BBWalletImportRepository.GetMany(kendoListRequest);
        }
        public async Task<int> GetTotalCount()
        {
            return await _unitOfWork.BBWalletImportRepository.Count();
        }
        public async Task<int> GetTotalCount(KendoListRequest kendoListRequest)
        {
            return await _unitOfWork.BBWalletImportRepository.Count(kendoListRequest);
        }
        public Task<int> GetTotalCount(ClaimsPrincipal identity)
        {
            return null;
        }
        /**
         * @TODO - currently not working, but has to be done for FULL CUSTOM QUERIES
         */
        public async Task<List<BBWalletImport>> ExecuteSQLQuery(string sqlCommand)
        {
            SqlConnection conn = new SqlConnection(this._appSettings.ConnectionString);

            conn.Open();

            List<BBWalletImport> records = new();
            SqlCommand command = new(sqlCommand, conn);

            using SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.HasRows)
            {
                DataTable dt = new();
                dt.Load(dataReader);

                foreach (DataRow row in dt.Rows)
                {
                    BBWalletImport record = new();
                    
                    record.Id = int.Parse(row["id"].ToString());
                    record.Uid = Guid.Parse(row["uid"].ToString());
                    record.UserUid = Guid.Parse(row["user_uid"].ToString());
                    record.Account = row["account"]?.ToString();
                    record.Category = row["category"]?.ToString();
                    record.Currency = row["currency"]?.ToString();
                    record.Amount = double.Parse(row["amount"].ToString());
                    record.RefCurrencyAmount = double.Parse(row["ref_currency_amount"].ToString());
                    record.Type = row["type"]?.ToString();
                    record.PaymentType = row["payment_type"]?.ToString();
                    record.PaymentTypeLocal = row["payment_type_local"]?.ToString();
                    record.Note = row["note"]?.ToString();
                    record.Date = DateTime.Parse(row["date"].ToString());
                    record.GpsLatitude = float.Parse(row["gps_latitude"].ToString());
                    record.GpsLongitude = float.Parse(row["gps_longitude"].ToString());
                    record.GpsAccuracyInMeters = float.Parse(row["gps_accuracy_in_meters"].ToString());
                    record.WarrantyInMonth = float.Parse(row["float"].ToString());
                    record.Transfer = bool.Parse(row["transfer"].ToString());
                    record.Payee = row["payee"]?.ToString();
                    record.Labels = row["labels"]?.ToString();
                    record.EnvelopeId = long.Parse(row["envelope_id"].ToString());
                    record.CustomCategory = bool.Parse(row["custom_category"].ToString());
                    record.CreatedAt = DateTime.Parse(row["created_at"].ToString());
                    record.CreatedByUserUid = Guid.Parse(row["created_by_user_uid"].ToString());
                    record.UpdatedAt = DateTime.Parse(row["updated_at"].ToString());
                    record.UpdatedByUserUid = Guid.Parse(row["updated_by_user_uid"].ToString());

                    records.Add(record);
                }

            }
            else
            {
                Console.WriteLine("Test");
            }

            conn.Close();

            return records;
        }
    }
}
