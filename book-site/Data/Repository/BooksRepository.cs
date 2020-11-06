using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class BooksRepository : IBooks
    {
        private readonly AppDBContent appDBContent;

        public BooksRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }

        public IEnumerable<Book> AllBooks => GetAuthorsAndGenres(appDBContent.Books.Include(obj => obj.Genre));

        public IEnumerable<Book> GetFavoriteBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsFavorite).Include(obj => obj.Genre));
        public IEnumerable<Book> GetStockBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsStock).Include(obj => obj.Genre));
        public IEnumerable<Book> GetNewBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsNew).Include(obj => obj.Genre));

        public Book GetBookById(int bookId)
        {
            var book = appDBContent.Books.FirstOrDefault(obj => obj.Id == bookId);
            book.Author = appDBContent.Authors.FirstOrDefault(obj => obj.Id == book.AuthorId);
            book.Genre = appDBContent.Genres.FirstOrDefault(obj => obj.Id == book.GenreId);
            return book;
        }

        private IEnumerable<Book> GetAuthorsAndGenres (IEnumerable<Book> list)
        {
            foreach (var book in list)
            {
                book.Author = appDBContent.Authors.FirstOrDefault(obj => obj.Id == book.AuthorId);
                book.Genre = appDBContent.Genres.FirstOrDefault(obj => obj.Id == book.GenreId);
            }
            return list;
        }
    }
}
