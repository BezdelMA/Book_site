using book_site.Data;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.Data.Repository;
using book_site.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Controllers
{
    [Authorize]
    public class ShopBasketController : Controller
    {
        private readonly IBooks _books;
        private readonly ShopBasket _shopBasket;
        private readonly AppDBContent _appDBContent;

        public ShopBasketController(IBooks books, ShopBasket shopBasket, AppDBContent appDBContent)
        {
            _books = books;
            _shopBasket = shopBasket;
            _appDBContent = appDBContent;
        }

        public ViewResult Basket()
        {
            var items = _shopBasket.GetBookBasket();
            _shopBasket.ListBookBasket = items;
            ShopBasketViewModel obj = new ShopBasketViewModel();
            obj.ShopBasket = _shopBasket;
            return View(obj);
        }

        public IActionResult AddToBasket(int id)
        {
            var item = _books.AllBooks.FirstOrDefault(obj => obj.Id == id);
            if (item != null)
            {
                _shopBasket.AddToBasket(item);
            }
            return RedirectToAction("Basket");
        }

        public IActionResult Plus(int BookId)
        {
            _appDBContent.BookBaskets.Where(bb => bb.BasketBookId == _shopBasket.BasketBookId).FirstOrDefault(b => b.Book.Id == BookId).Counter += 1;
            _appDBContent.SaveChanges();
            return RedirectToAction("Basket");
        }

        public IActionResult Minus(int BookId)
        {
            if (_appDBContent.BookBaskets.Where(bb => bb.BasketBookId == _shopBasket.BasketBookId).FirstOrDefault(b => b.Book.Id == BookId).Counter > 1)
            {
                _appDBContent.BookBaskets.Where(bb => bb.BasketBookId == _shopBasket.BasketBookId).FirstOrDefault(b => b.Book.Id == BookId).Counter -= 1;
                _appDBContent.SaveChanges();
            }
            else
            {
                _appDBContent.BookBaskets.Remove(_appDBContent.BookBaskets.Where(bb => bb.BasketBookId == _shopBasket.BasketBookId).FirstOrDefault(b => b.Book.Id == BookId));
                _appDBContent.SaveChanges();
            }
            return RedirectToAction("Basket");
        }
    }
}
