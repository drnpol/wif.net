using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIF.Base.ImportService.Models
{
    public class FileConfig
    {
       public String Path { get; set; }
       public String Type { get; set; }
       public String Delimiter { get; set; }
       public int StartLine { get; set; }
       public String Model { get; set; }

       public override string ToString()
       {
            return $@"
                'Path': '{this.Path}',
                'Type': '{this.Type}',
                'Delimiter': '{this.Delimiter}',
                'StartLine': {this.StartLine},
                'Model': {this.Model}
            ";
       }
    }
}
