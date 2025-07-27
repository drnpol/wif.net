using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.PortfolioManager.Domain.Models
{
    public class ModelBase
    {
        public Guid Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserUid {get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? UpdatedByUserUid { get; set; }
    }
}
