using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure;
using WIF.Core.DTOs.BBWalletImport;
using WIF.Core.Helpers;
using WIF.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WIF.Core.Extensions.Models
{
    internal static class BBWalletImportExtension
    {
        internal static BBWalletImportListDto Map(this BBWalletImport self)
        {
            return new BBWalletImportListDto()
            {
                Id = self.Id,
                Uid = self.Uid.ToString(),
                UserUid = self.UserUid.ToString(),
                Account = self.Account,
                Category = self.Category,
                Currency = self.Currency,
                Amount = self.Amount,
                Type = self.Type,
                Date = ((DateTime)self.Date).ToString("dd.MM.yyyy"),
                Transfer = self.Transfer,
                Payee = self.Payee,
                Labels = self.Labels
            };
        }
    }
}
