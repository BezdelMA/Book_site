using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class GenreRepository : IBooksGenre
    {
        private readonly AppDBContent appDBContent;

        public GenreRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }
        public IEnumerable<Genre> AllGenres => appDBContent.Genres;

        public IEnumerable<Genre> Genres (IEnumerable<Book> filter)
        {
            List<Genre> _genres = new List<Genre>();
            foreach(var item in filter)
            {
                if (!_genres.Contains(item.Genre))
                {
                    _genres.Add(item.Genre);
                }
            }
            return _genres;
        }
    }
}
