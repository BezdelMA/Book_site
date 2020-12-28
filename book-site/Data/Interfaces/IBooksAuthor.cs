using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Interfaces
{
    public interface IBooksAuthor
    {
        IEnumerable<Author> AllAuthors { get; }

        IEnumerable<Author> Authors(IEnumerable<Book> filter);

        void AddAuthor(string nameAuthor);

        void RemoveAuthor(Author author);

        void EditAuthor(Author author);
    }
}
