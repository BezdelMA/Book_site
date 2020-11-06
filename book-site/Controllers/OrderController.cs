using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopBasket _shopBasket;
        private readonly IServiceProvider _service;

        public OrderController(IAllOrders allOrders, ShopBasket shopBasket, IServiceProvider service)
        {
            _allOrders = allOrders;
            _shopBasket = shopBasket;
            _service = service;
        }

        public IActionResult Checkout()
        {
            _shopBasket.ListBookBasket = _shopBasket.GetBookBasket();
            if (_shopBasket.ListBookBasket.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
                return RedirectToAction("Basket", "ShopBasket");
            }
            else
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            _shopBasket.ListBookBasket = _shopBasket.GetBookBasket();
            if (_shopBasket.ListBookBasket.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
            }

            if (order.Name.Equals("QWE") || order.SurName.Equals("QWE"))
            {
                ModelState.AddModelError("", "Странные имя и фамилия");
            }

            else
            {
                if (ModelState.IsValid)
                {
                    _allOrders.CreateOrder(order);
                    ShopBasket.CloseSession(_service);
                    return View("Complete", order);
                }
                
            }
            return View(order);
        }

    }
}
