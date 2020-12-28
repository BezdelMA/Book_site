using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Areas.Admin.ViewModel;
using book_site.Data;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace book_site.Areas.Admin.Controllers
{
    [Area(Role.Admin), Authorize(Roles = Role.Admin)]
    public class AllProductsController : Controller
    {
        private readonly AppDBContent _appDBContent;
        private readonly IBooks _books;
        private readonly IBooksAuthor _author;
        private readonly IBooksGenre _genre;

        public AllProductsController(AppDBContent appDBContent, IBooks books, IBooksAuthor author, IBooksGenre genre)
        {
            _appDBContent = appDBContent;
            _books = books;
            _author = author;
            _genre = genre;
        }

        public IActionResult AllProduct()
        {
            var obj = new AllProductViewModel()
            {
                AllProducts = _books.AllBooks.Select(o => new AllProductViewModel
                {
                    Id = o.Id,
                    NameBook = o.NameBook,
                    Author = o.Author.NameAuthor,
                    Genre = o.Genre.NameGenre,
                    Annotation = o.Annotation,
                    Img = o.Img,
                    PublishingHouse = o.PublishingHouse,
                    Price = o.Price,
                    Year = o.Year,
                    IsNew = o.IsNew,
                    IsStock = o.IsStock,
                    IsFavorite = o.IsFavorite
                })
            };
            return View(obj);
        }

        public IActionResult CreateProduct()
        {
            var obj = new AllProductViewModel()
            {
                Authors = _author.AllAuthors,
                Genres = _genre.AllGenres
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult CreateProduct(AllProductViewModel product)
        {
            if (ModelState.IsValid)
            {

                string fileName = "../img/Catalog/" + _books.UpLoadFile(product.ImgFile);
                _books.CreateBook(new Book
                {
                    NameBook = product.NameBook,
                    NormalizedNameBook = product.NameBook.ToUpper(),
                    AuthorId = Int32.Parse(Request.Form.FirstOrDefault(o => o.Key == "authors").Value.ToString()),
                    Annotation = product.Annotation,
                    PublishingHouse = product.PublishingHouse,
                    Img = fileName,
                    Price = product.Price,
                    Year = product.Year,
                    IsFavorite = product.IsFavorite,
                    IsNew = product.IsNew,
                    IsStock = product.IsStock,
                    GenreId = Int32.Parse(Request.Form.FirstOrDefault(o => o.Key == "genres").Value.ToString())
                });
                return RedirectToAction("AllProduct");
            }

            else
            {
                product.Genres = _genre.AllGenres;
                product.Authors = _author.AllAuthors;
                return View(product);
            }
        }

        public IActionResult EditProduct(int BookId)
        {
            var book = _books.GetBookById(BookId);
            var obj = new AllProductViewModel
            {
                Id = book.Id,
                NameBook = book.NameBook,
                Author = _author.AllAuthors.FirstOrDefault(a => a.Id == book.AuthorId).NameAuthor,
                Genre = _genre.AllGenres.FirstOrDefault(g => g.Id == book.GenreId).NameGenre,
                Annotation = book.Annotation,
                Img = book.Img,
                PublishingHouse = book.PublishingHouse,
                Price = book.Price,
                Year = book.Year,
                IsNew = book.IsNew,
                IsStock = book.IsStock,
                IsFavorite = book.IsFavorite,
                Authors = _appDBContent.Authors,
                Genres = _appDBContent.Genres
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditProduct(AllProductViewModel product)
        {
            string fileName = "../img/Catalog/" + _books.UpLoadFile(product.ImgFile);
            var book = _books.GetBookById(product.Id);
            var obj = new Book
            {
                Id = book.Id,
                NameBook = product.NameBook,
                NormalizedNameBook = product.NameBook.ToUpper(),
                AuthorId = Int32.Parse(Request.Form.FirstOrDefault(o => o.Key == "authors").Value.ToString()),
                GenreId = Int32.Parse(Request.Form.FirstOrDefault(o => o.Key == "genres").Value.ToString()),
                Annotation = product.Annotation,
                Img = fileName,
                PublishingHouse = product.PublishingHouse,
                Price = product.Price,
                Year = product.Year,
                IsNew = product.IsNew,
                IsStock = product.IsStock,
                IsFavorite = product.IsFavorite
            };
            _books.EditBook(obj);
            return RedirectToAction("AllProduct");
        }

        public IActionResult DeleteProduct(int BookId)
        {
            var book = _books.GetBookById(BookId);
            var obj = new AllProductViewModel
            {
                Id = BookId,
                NameBook = book.NameBook,
                Author = _author.AllAuthors.FirstOrDefault(a => a.Id == book.AuthorId).NameAuthor,
                Genre = _genre.AllGenres.FirstOrDefault(g => g.Id == book.GenreId).NameGenre,
                Annotation = book.Annotation,
                Img = book.Img,
                PublishingHouse = book.PublishingHouse,
                Price = book.Price,
                Year = book.Year,
                IsNew = book.IsNew,
                IsStock = book.IsStock,
                IsFavorite = book.IsFavorite
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeleteProduct(AllProductViewModel product)
        {
            var book = _books.GetBookById(product.Id);
            if (book != null)
            {
                _books.DeleteBook(book);
            }
            return RedirectToAction("AllProduct");
        }

        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(string nameGenre)
        {
            _genre.AddGenre(nameGenre);
            return RedirectToAction("CreateProduct");
        }
    }
}