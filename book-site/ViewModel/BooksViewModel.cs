using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class BooksViewModel
    {
        public Book BookById { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Book> FavoriteBooks { get; set; }
        public IEnumerable<Book> NewBooks { get; set; }
        public IEnumerable<Book> StockBooks { get; set; }
    }
}
