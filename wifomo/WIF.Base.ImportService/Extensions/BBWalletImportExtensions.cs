using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WIF.Core.Models;

namespace WIF.Base.ImportService.Extensions
{
    public static class BBWalletImportExtensions
    {
        public static string ToCustomString(this BBWalletImport self)
        {
            return $"'id': '{self.Id}', 'uid': '{self.Uid}', 'description': {self.Note}";
        }
    }
}
