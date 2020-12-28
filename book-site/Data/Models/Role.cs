using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Role : IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
