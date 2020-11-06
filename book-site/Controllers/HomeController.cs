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

        public ViewResult Index()
        {
            ViewBag.Title = "Мир книг | интернет-магазин книг г. Подольска | доставка по Подольску и Москве";
            BooksViewModel obj = new BooksViewModel();
            obj.NewBooks = _books.GetNewBooks;
            obj.StockBooks = _books.GetStockBooks;
            obj.FavoriteBooks = _books.GetFavoriteBooks;
            return View(obj);
        }

        public ViewResult BookId(int id)
        {
            BooksViewModel obj = new BooksViewModel();
            obj.BookById = _books.GetBookById(id);
            obj.FavoriteBooks = _books.GetFavoriteBooks;
            return View(obj);
        }
    }
}
