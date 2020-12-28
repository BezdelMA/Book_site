using book_site.Data;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Controllers
{

    public class CatalogController : Controller
    {
        private readonly IBooks _books;
        private readonly IBooksGenre _booksGenre;
        private readonly IBooksAuthor _booksAuthor;
        private readonly AppDBContent _appDBContent;

        public CatalogController(IBooks books, IBooksGenre booksGenres, IBooksAuthor booksAuthors, AppDBContent appDBContent)
        {
            _books = books;
            _booksGenre = booksGenres;
            _booksAuthor = booksAuthors;
            _appDBContent = appDBContent;
        }

        [Route("Catalog")]
        [Route("Catalog/Books/{filter}")]
        public ViewResult Books(string filter)
        {
            CatalogViewModel obj = new CatalogViewModel();

            if (string.IsNullOrEmpty(filter))
            {
                obj.Books = _books.AllBooks;
                obj.Genres = _booksGenre.AllGenres;
                obj.Authors = _booksAuthor.AllAuthors;
            }

            else
            {
                if (string.Equals("Favorite", filter, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Books = _books.GetFavoriteBooks;
                }
                else if (string.Equals("New", filter, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Books = _books.GetNewBooks;
                }
                else if (string.Equals("Stock", filter, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Books = _books.GetStockBooks;
                }
                obj.Genres = _booksGenre.Genres(obj.Books);
                obj.Authors = _booksAuthor.Authors(obj.Books);
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            CatalogViewModel obj = new CatalogViewModel()
            {
                Genres = _booksGenre.AllGenres,
                Authors = _booksAuthor.AllAuthors
            };

            if (string.IsNullOrEmpty(search))
            {
                obj.Books = _books.AllBooks;
                return View("Books", obj);
            }

            else
            {
                search = search.ToUpper();

                var searchAuthor = _appDBContent.Authors.Where(a => a.NormalizedNameAuthor.Contains(search.ToUpper())).ToList();
                //_booksAuthor.AllAuthors.Where(o => o.NormalizedNameAuthor.Contains(search)).ToList();
                var items = _appDBContent.Books.Where(b => b.NormalizedNameBook.Contains(search.ToUpper())).ToList();
                //_books.AllBooks.Where(o => o.NormalizedNameBook.Contains(search)).ToList();
                var searchGenre = _appDBContent.Genres.Where(g => g.NormalizedNameGenre.Contains(search.ToUpper())).ToList();
                    //_booksGenre.AllGenres.Where(o => o.NormalizedNameGenre.Contains(search)).ToList();
                foreach (var item in searchAuthor)
                {
                    items.AddRange(_books.AllBooks.Where(o => o.Author == item));
                }
                foreach (var item in searchGenre)
                {
                    items.AddRange(_books.AllBooks.Where(o => o.Genre == item));
                }
                obj.Books = items;
                return View("Books", obj);
            }
        }

        [HttpPost]
        public ActionResult Filter()
        {
            List<string> genres = Request.Form.FirstOrDefault(o => o.Key == "genres").Value.ToList();
            List<string> authors = Request.Form.FirstOrDefault(o => o.Key == "authors").Value.ToList();

            CatalogViewModel obj = new CatalogViewModel();
            List<Book> lBooks = new List<Book>();


            if (genres.Count > 0 || authors.Count > 0)
            {
                foreach (var item in genres)
                {
                    lBooks.AddRange(_books.AllBooks.Where(o => o.GenreId == Int32.Parse(item)));
                }

                foreach (var item in authors)
                {
                    lBooks.AddRange(_books.AllBooks.Where(o => o.AuthorId == Int32.Parse(item)));
                }
                obj.Books = lBooks;
            }
            else
            {
                obj.Books = _books.AllBooks;
            }

            obj.Genres = _booksGenre.AllGenres;
            obj.Authors = _booksAuthor.AllAuthors;
            return View("Books", obj);
        }
    }
}
