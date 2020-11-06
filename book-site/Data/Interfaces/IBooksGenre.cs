using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Interfaces
{
    public interface IBooksGenre
    {
        IEnumerable<Genre> AllGenres { get; }

        IEnumerable<Genre> Genres(IEnumerable<Book> filter);
    }
}
