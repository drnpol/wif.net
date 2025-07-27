using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq.Expressions;
using WIF.PortfolioManager.Domain.Models;
using Microsoft.Data.SqlClient;
using System.Data;

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
        /**
         * @TODO - currently not working, but has to be done for FULL CUSTOM QUERIES
         */
        public async Task<List<BBWalletImport>> ExecuteSQLQuery(string sqlCommand)
        {
            SqlConnection conn = new SqlConnection(this.DbContext.Database.GetDbConnection().ConnectionString);

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
