using book_site.Data.Interfaces;
using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Mocks
{
    public class MockGenre : IBooksGenre
    {
        public IEnumerable<Genre> AllGenres
        {
            get
            {
                return new List<Genre>
                {
                    new Genre{NameGenre = "Комедия"},
                    new Genre{NameGenre = "Роман"},
                    new Genre{NameGenre = "Драма"},
                    new Genre{NameGenre = "О войне"},
                    new Genre{NameGenre = "Исторические"}
            };
            }
        }

        public IEnumerable<Genre> Genres(IEnumerable<Book> filter)
        {
            throw new NotImplementedException();
        }
    }
}
