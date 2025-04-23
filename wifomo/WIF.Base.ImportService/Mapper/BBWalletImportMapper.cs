using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using WIF.Base.ImportService.Helpers;
using WIF.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WIF.Base.ImportService.Mapper
{
    class BBWalletImportMapper : ClassMap<BBWalletImport>
    {
        public BBWalletImportMapper()
        {
            if (true)
            {
                //Map(p => p.Id).Name("id");
                //Map(p => p.Uid).Name("uid");
                Map(p => p.UserUid).Name("user_uid");
                Map(p => p.Account).Name("account");
                Map(p => p.Category).Name("category");
                Map(p => p.Currency).Name("currency");
                Map(p => p.Amount).Name("amount");
                Map(p => p.RefCurrencyAmount).Name("ref_currency_amount");
                Map(p => p.Type).Name("type");
                Map(p => p.PaymentType).Name("payment_type");
                Map(p => p.PaymentTypeLocal).Name("payment_type_local");
                Map(p => p.Note).Name("note");
                Map(p => p.Date).Name("date").TypeConverter<MultiFormatDateConverter>();
                Map(p => p.GpsLatitude).Name("gps_latitude");
                Map(p => p.GpsLongitude).Name("gps_longitude");
                Map(p => p.GpsAccuracyInMeters).Name("gps_accuracy_in_meters");
                Map(p => p.WarrantyInMonth).Name("warranty_in_month");
                Map(p => p.Transfer).Name("transfer");
                Map(p => p.Payee).Name("payee");
                Map(p => p.Labels).Name("labels");
                Map(p => p.EnvelopeId).Name("envelope_id");
                Map(p => p.CustomCategory).Name("custom_category");
                //Map(p => p.CreatedAt).Name("created_at");
                Map(p => p.CreatedByUserUid).Name("created_by_user_uid");
                //Map(p => p.UpdatedAt).Name("updated_at");
                Map(p => p.UpdatedByUserUid).Name("updated_by_user_uid");
            }
            else
            {
                //Map(p => p.Id).Index(0);
                //Map(p => p.Uid).Index(1);
                Map(p => p.UserUid).Index(2);
                Map(p => p.Account).Index(3);
                Map(p => p.Category).Index(4);
                Map(p => p.Currency).Index(5);
                Map(p => p.Amount).Index(6);
                Map(p => p.RefCurrencyAmount).Index(7);
                Map(p => p.Type).Index(8);
                Map(p => p.PaymentType).Index(9);
                Map(p => p.PaymentTypeLocal).Index(10);
                Map(p => p.Note).Index(11);
                Map(p => p.Date).Index(12);
                Map(p => p.GpsLatitude).Index(13);
                Map(p => p.GpsLongitude).Index(14);
                Map(p => p.GpsAccuracyInMeters).Index(15);
                Map(p => p.WarrantyInMonth).Index(16);
                Map(p => p.Transfer).Index(17);
                Map(p => p.Payee).Index(18);
                Map(p => p.Labels).Index(19);
                Map(p => p.EnvelopeId).Index(20);
                Map(p => p.CustomCategory).Index(21);
                //Map(p => p.CreatedAt).Index(22);
                Map(p => p.CreatedByUserUid).Index(23);
                //Map(p => p.UpdatedAt).Index(24);
                Map(p => p.UpdatedByUserUid).Index(25);
            }
        }
    }
}
