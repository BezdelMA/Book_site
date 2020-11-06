using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class CatalogViewModel
    {
        public Book BookById { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<string> PublishingHouse { get; set; }
        public IEnumerable<int> Year { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
