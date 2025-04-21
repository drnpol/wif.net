using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WIF.Core.Enums;

namespace WIF.Core.Models
{
    public class Role : IdentityRole<string>
    {
    }
}
