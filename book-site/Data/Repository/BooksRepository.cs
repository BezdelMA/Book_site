using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class BooksRepository : IBooks
    {
        private readonly AppDBContent appDBContent;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksRepository(AppDBContent _appDBContent, IWebHostEnvironment _webHostEnvironment)
        {
            appDBContent = _appDBContent;
            webHostEnvironment = _webHostEnvironment;
        }

        public IEnumerable<Book> AllBooks => GetAuthorsAndGenres(appDBContent.Books.Include(obj => obj.Genre));

        public IEnumerable<Book> GetFavoriteBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsFavorite).Include(obj => obj.Genre));
        public IEnumerable<Book> GetStockBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsStock).Include(obj => obj.Genre));
        public IEnumerable<Book> GetNewBooks => GetAuthorsAndGenres(appDBContent.Books.Where(obj => obj.IsNew).Include(obj => obj.Genre));

        public Book GetBookById(int bookId)
        {
            var book = appDBContent.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefault(b => b.Id == bookId);
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

        public void CreateBook (Book book)
        {
            appDBContent.Books.Add(book);
            appDBContent.SaveChanges();
        }

        public void EditBook(Book book)
        {
            var _book = appDBContent.Books.FirstOrDefault(b => b.Id == book.Id);
            appDBContent.Remove(_book);
            appDBContent.Add(book);
            appDBContent.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            appDBContent.BookBaskets.RemoveRange(appDBContent.BookBaskets.Where(bb => bb.Book == book));
            appDBContent.Books.Remove(book);
            appDBContent.SaveChanges();
        }

        public string UpLoadFile (IFormFile file)
        {
            string fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "img/catalog");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
