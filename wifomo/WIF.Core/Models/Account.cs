using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WIF.Core.Models
{
    public class Account: ModelBase
    {
        public Guid UserUid { get; set; }
        public int AccountType { get; set; }// int or id?

        public string Name { get; set; } = string.Empty;

        public string AccountNumber { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}
