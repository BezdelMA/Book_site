using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.ViewModel;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> userManager;
        private readonly IAdress _adress;

        public OrderController(IAllOrders allOrders, IAdress adress, ShopBasket shopBasket, UserManager<User> _userManager, IServiceProvider service)
        {
            _allOrders = allOrders;
            _shopBasket = shopBasket;
            _adress = adress;
            _service = service;
            userManager = _userManager;
        }

        public async Task<IActionResult> Checkout()
        {
            _shopBasket.ListBookBasket = _shopBasket.GetBookBasket();
            if (_shopBasket.ListBookBasket.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста");
                return RedirectToAction("Basket", "ShopBasket");
            }
            else
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var adress = _adress.GetAdressByUserId(user.Id);

                if (adress is null)
                {
                    int newId = 0;
                    if (!_adress.GetAllAdresses.Any())
                        newId = 1;
                    else
                    {
                        newId = _adress.GetAllAdresses.Max(a => a.Id) + 1;
                    }
                    adress = new Adress() { Id = newId, UserId = user.Id};
                }

                var order = new CheckoutViewModel()
                {
                    SurName = user.SurName,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Country = adress.Country,
                    City = adress.City,
                    Street = adress.Street,
                    House = adress.House,
                    Building = adress.Building,
                    Floor = adress.Floor,
                    Flat = adress.Flat,
                    UserId = user.Id,
                    AdressId = adress.Id
                };
                return View(order);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            else
            {
                if (!_adress.GetAllAdresses.Any(a => a.Id == model.AdressId))
                    _adress.CreateAdress(new Adress() 
                    {
                        Country = model.Country,
                        City = model.City,
                        Street = model.Street,
                        House = model.House,
                        Building = model.Building,
                        Flat = model.Flat,
                        Floor = model.Floor
                    });
                var items = _shopBasket.GetBookBasket();
                _shopBasket.ListBookBasket = items;
                var adress = _adress.GetAdressById(model.AdressId);
                var user = await userManager.FindByIdAsync(model.UserId);
                var order = new Order()
                {
                    UserId = model.UserId,
                    User = user,
                    AdressId = model.AdressId,
                    Adress = adress,
                    AllPrice = _shopBasket.AllPrice
                };

                _allOrders.CreateOrder(order);
                ShopBasket.CloseSession(_service);
                return View("Complete", order);
            }
        }
    }
}
