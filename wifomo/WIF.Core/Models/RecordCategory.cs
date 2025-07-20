using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.Core.Models
{
    public class RecordCategory
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; } // allow nesting 
        public string Name { get; set; } = string.Empty;
        public string Alias { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
