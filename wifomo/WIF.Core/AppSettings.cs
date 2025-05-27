using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WIF.Core
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public AppSettings(IConfiguration config)
        {
            this.ConnectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}
