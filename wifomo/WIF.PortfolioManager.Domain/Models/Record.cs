using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Domain.Models
{
    public class Record: ModelBase
    {
        public string UserUid { get; set; } = string.Empty;
        public Guid AccountUid { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal? RefCurrencyAmount { get; set; }
        public int TypeId { get; set; } //int or id?
        public virtual RecordType RecordType { get; set; }
        public int StatusId { get; set; } //int or id?
        public virtual RecordStatus RecordStatus { get; set; }
        public int PaymentTypeId { get; set; } //int or id?
        public virtual PaymentType PaymentType {get; set;}
        //public string? PaymentTypeLocal { get; set; }
        public string? Note { get; set; }
        public DateTime Date { get; set; }
        //public double? GpsLatitude { get; set; }
        //public double? GpsLongitude { get; set; }
        //public double? GpsAccuracyInMeters { get; set; }
        //public int? WarrantyInMonth { get; set; }
        public string? Transfer { get; set; }
        public string? Payee { get; set; }
        public string? Labels { get; set; }
        //public string? EnvelopeId { get; set; }
        //public string? CustomCategory { get; set; }
    }
}
