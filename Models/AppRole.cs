using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataSekolahWithIdentity.Models
{
    public class AppRole : IdentityUser
    {
        public string Role { get; set; }
    }
}
