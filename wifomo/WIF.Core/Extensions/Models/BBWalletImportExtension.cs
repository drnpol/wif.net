using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WIF.PortfolioManager.Application.DTOs.BBWalletImport;
using WIF.PortfolioManager.Application.Helpers;
using WIF.PortfolioManager.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WIF.PortfolioManager.Application.Extensions.Models
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
