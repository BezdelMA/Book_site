using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Areas.Admin.ViewModel
{
    public class OrderDetailsViewModel
    {
        public string NameBook { get; set; }
        public string ImgURL { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }
        public int Price { get; set; }
        public int Counter { get; set; }
        public int AllPrice { 
            get
            {
                return Price * Counter;
            }
            set
            {

            }
        }


    }
}
