using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.ViewModel;
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

        public CatalogController (IBooks books, IBooksGenre booksGenres, IBooksAuthor booksAuthors)
        {
            _books = books;
            _booksGenre = booksGenres;
            _booksAuthor = booksAuthors;
        }

        [Route("Catalog")]
        [Route("Catalog/Books/{filter}")]
        public ViewResult Books(string filter)
        {
            CatalogViewModel obj = new CatalogViewModel();

            if(string.IsNullOrEmpty(filter))
            {
                obj.Books = _books.AllBooks;
                obj.Genres = _booksGenre.AllGenres;
                obj.Authors = _booksAuthor.AllAuthors;
            }

            else
            {
                if(string.Equals("Favorite", filter, StringComparison.OrdinalIgnoreCase))
                {
                    obj.Books = _books.GetFavoriteBooks;
                }
                else if(string.Equals("New", filter, StringComparison.OrdinalIgnoreCase))
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
        public ViewResult Search(string search)
        {
            CatalogViewModel obj = new CatalogViewModel();
            var items = _books.AllBooks.Where(o => o.NameBook.Contains(search)).ToList();
            var searchAuthor = _booksAuthor.AllAuthors.Where(o => o.NameAuthor.Contains(search)).ToList();
            var searchGenre = _booksGenre.AllGenres.Where(o => o.NameGenre.Contains(search)).ToList();
            foreach (var item in searchAuthor)
            {
                items.AddRange(_books.AllBooks.Where(o => o.Author == item));
            }
            foreach (var item in searchGenre)
            {
                items.AddRange(_books.AllBooks.Where(o => o.Genre == item));
            }
            obj.Books = items;
            obj.Genres = _booksGenre.Genres(obj.Books);
            obj.Authors = _booksAuthor.Authors(obj.Books);
            return View("Books", obj);
        }

        [HttpPost]
        public ActionResult Filter()
        {
            List<string> genres = Request.Form.FirstOrDefault(o => o.Key == "genres").Value.ToList();
            List<string> authors = Request.Form.FirstOrDefault(o => o.Key == "authors").Value.ToList();
            CatalogViewModel obj = new CatalogViewModel();
            List<Book> lBooks = new List<Book>();
            List<Genre> lGenres = new List<Genre>();
            List<Author> lAuthors = new List<Author>();
            if (genres.Count > 0 || authors.Count > 0)
            {
                foreach (var item in genres)
                {
                    lGenres.AddRange(_booksGenre.AllGenres.Where(o => o.NameGenre == item));
                }
                foreach (var item in lGenres)
                {
                    lBooks.AddRange(_books.AllBooks.Where(o => o.Genre == item));
                }
                foreach (var item in authors)
                {
                    lAuthors.AddRange(_booksAuthor.AllAuthors.Where(o => o.NameAuthor == item));
                }

                for (int i = lBooks.Count - 1; i >= 0; i--)
                {
                    int j = 0;
                    foreach (var item in lAuthors)
                    {
                        if (lBooks[i].Author == item)
                        {
                            j++;
                        }
                    }
                    if (j == 0)
                    {
                        lBooks.RemoveAt(i);
                    }
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
