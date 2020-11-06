using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class BookBasket
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Price {
            get;
            //return (Book.Price * Counter);
            set;  
        }
        public int Counter { get; set; }
        public string BasketBookId { get; set; }
    }
}
