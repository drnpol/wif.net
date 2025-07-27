using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Domain.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
