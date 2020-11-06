using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string NameGenre { get; set; }
        public IEnumerable<Book> BooksGenre { get; set; }
    }
}
