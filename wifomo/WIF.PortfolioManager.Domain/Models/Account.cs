using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Domain.Models
{
    public class Account: ModelBase
    {
        public Guid UserUid { get; set; }
        public int TypeId { get; set; }// int or id?
        public virtual AccountType AccountType { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
