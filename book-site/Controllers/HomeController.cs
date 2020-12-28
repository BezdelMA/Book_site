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
    public class HomeController : Controller
    {
        private readonly IBooks _books;
        private readonly IBooksGenre _booksGenre;
        private readonly IBooksAuthor _booksAuthor;

        public HomeController (IBooks books, IBooksGenre booksGenre, IBooksAuthor booksAuthor)
        {
            _books = books;
            _booksGenre = booksGenre;
            _booksAuthor = booksAuthor;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Мир книг | интернет-магазин книг г. Подольска | доставка по Подольску и Москве";
            BooksViewModel obj = new BooksViewModel();
            obj.NewBooks = _books.GetNewBooks;
            obj.StockBooks = _books.GetStockBooks;
            obj.FavoriteBooks = _books.GetFavoriteBooks;
            return View(obj);
        }

        public IActionResult BookId(int id)
        {
            BooksViewModel obj = new BooksViewModel();
            var book = _books.GetBookById(id);
            if (book is null)
                return NotFound();
            else
            {
                obj.BookById = book;
                obj.FavoriteBooks = _books.GetFavoriteBooks;
                return View(obj);
            }
        }
    }
}
