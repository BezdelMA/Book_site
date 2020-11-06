using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.Data.Repository;
using book_site.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Controllers
{
    public class ShopBasketController : Controller
    {
        private readonly IBooks _books;
        private readonly ShopBasket _shopBasket;

        public ShopBasketController(IBooks books, ShopBasket shopBasket)
        {
            _books = books;
            _shopBasket = shopBasket;
        }

        public ViewResult Basket()
        {
            var items = _shopBasket.GetBookBasket();
            _shopBasket.ListBookBasket = items;
            ShopBasketViewModel obj = new ShopBasketViewModel();
            obj.ShopBasket = _shopBasket;
            return View(obj);
        }

        public RedirectToActionResult AddToBasket(int id)
        {
            var item = _books.AllBooks.FirstOrDefault(obj => obj.Id == id);
            if (item != null)
            {
                _shopBasket.AddToBasket(item);
            }
            return RedirectToAction("Basket");
        }
    }
}
