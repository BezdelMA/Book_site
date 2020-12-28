using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public string NormalizedNameAuthor { get; set; }
        public List<Book> BooksAuthor { get; set; }
    }
}
