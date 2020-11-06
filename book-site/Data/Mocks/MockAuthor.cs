using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Mocks
{
    public class MockAuthor : IBooksAuthor
    {
        public IEnumerable<Author> AllAuthors
        {
            get
            {
                return new List<Author>
                {
                    new Author{NameAuthor="1"},
                    new Author{NameAuthor="2"},
                    new Author{NameAuthor="3"},
                    new Author{NameAuthor="4"},
                    new Author{NameAuthor="5"}
                };
            }
        }

        public IEnumerable<Author> Authors(IEnumerable<Book> filter)
        {
            throw new NotImplementedException();
        }
    }
}
