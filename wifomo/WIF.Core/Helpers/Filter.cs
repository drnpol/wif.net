using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.Core.Helpers
{
    public class Filter<T>
    {
        public string Name { get; set; }
        public string Alias { get; set; } // for custom names of DTO or request
        public string Value { get; set; }
        public string Operator { get; set; }
    }
}
