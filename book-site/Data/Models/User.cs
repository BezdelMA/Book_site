using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace book_site.Data.Models
{
    public class User : IdentityUser
    {
        public const string Admin = "Admin";
        public const string AdminDefaultPassword = "p1c1TB4i";

        public string SurName { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
