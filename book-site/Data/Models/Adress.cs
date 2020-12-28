using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Building { get; set; }
        public int Flat { get; set; }
        public int Floor { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
