using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class UserViewModel
    {
        IEnumerable<Order> Orders { get; set; }

    }
}
