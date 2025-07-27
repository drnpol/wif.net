using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.Application.DTOs.BBWalletImport
{
    public class BBWalletImportListDto
    {
        public long Id { get; set; }
        public string? Uid { get; set; }
        public string? UserUid { get; set; }
        public string? Account { get; set; }
        public string? Category { get; set; }
        public string? Currency { get; set; }
        public double? Amount { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public bool? Transfer { get; set; }
        public string? Payee { get; set; }
        public string? Labels { get; set; }
    }
}
