using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WIF.Core.Models;

namespace WIF.Base.ImportService.Extensions
{
    public static class BBWalletImportExtensions
    {
        public static string ToString(this BBWalletImport self)
        {
            return $"'id': '{self.Id}', 'uid': '{self.Uid}', 'description': {self.Note}";
        }
        public static bool Equals(this BBWalletImport self, BBWalletImport other)
        {
            if(
                self.Account == other.Account &&
                self.Category == other.Category &&
                self.Currency == other.Currency &&
                self.Amount == other.Amount &&
                self.Type == other.Type &&
                self.PaymentType == other.PaymentType &&
                self.Date == other.Date &&
                self.EnvelopeId == other.EnvelopeId
            )
            {
                return true;
            }

            return false;
        }
    }
}
