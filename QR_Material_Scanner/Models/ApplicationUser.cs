using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QR_Material_Scanner.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Plant { get; set; }
    }
}
