using book_site.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Components
{
    public class BasketComponent : ViewComponent
    {
        private readonly ShopBasket _shopBasket;

        public BasketComponent(ShopBasket shopBasket) => _shopBasket = shopBasket;
        public IViewComponentResult Invoke()
        {
            var items = _shopBasket.GetBookBasket();
            _shopBasket.ListBookBasket = items;
            int i = 0;
            foreach (var item in _shopBasket.ListBookBasket)
            {
                i += item.Counter;
            }
            ViewBag.Count = i;
            return View();
        }
    }
}
