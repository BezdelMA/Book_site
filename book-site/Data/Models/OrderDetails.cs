﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Counter { get; set; }
        public int Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }

    }
}
