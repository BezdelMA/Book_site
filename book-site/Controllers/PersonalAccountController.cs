using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using book_site.Data;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_site.Controllers
{
    public class PersonalAccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IAdress _adress;
        private readonly IAllOrders _allOrders;
        private readonly AppDBContent _appDBContent;

        public PersonalAccountController(UserManager<User> _userManager, IAdress adress, IAllOrders allOrders, AppDBContent appDBContent)
        {
            userManager = _userManager;
            _adress = adress;
            _allOrders = allOrders;
            _appDBContent = appDBContent;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserInfo()
        {
            var userName = User.Identity.Name;
            var user = await userManager.FindByNameAsync(userName);

            Adress adress = new Adress();

            if (!_adress.GetAllAdresses.Any(a => a.UserId == user.Id))
            {
                adress.UserId = user.Id;
            }

            else
                adress = _adress.GetAllAdresses.FirstOrDefault(a => a.UserId == user.Id);

            var obj = new UserInfoViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                SurName = user.SurName,
                Name = user.Name,
                BirthDate = user.BirthDate,
                PhonNumber = user.PhoneNumber,
                Email = user.Email,
                AdressId = adress.Id,
                Country = adress.Country,
                City = adress.City,
                Street = adress.Street,
                House = adress.House,
                Building = adress.Building,
                Flat = adress.Flat,
                Floor = adress.Floor
            };

            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> UserInfo(UserInfoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if (user is null)
                {
                    return NotFound();
                }
                else
                {
                    user.UserName = model.UserName;
                    user.NormalizedUserName = model.UserName.ToUpper();
                    user.Name = model.Name;
                    user.SurName = model.SurName;
                    user.BirthDate = model.BirthDate;
                    user.Email = model.Email;
                    user.NormalizedEmail = model.Email.ToUpper();
                    user.PhoneNumber = model.PhonNumber;
                    var edit_result = await userManager.UpdateAsync(user);

                    if (!edit_result.Succeeded)
                    {
                        var errors = edit_result.Errors.Select(e => e.Description);
                        ModelState.AddModelError("", string.Join(", ", errors));
                        return View(model);
                    }

                    var modelAdress = new Adress()
                    {
                        Id = model.AdressId,
                        Country = model.Country,
                        City = model.City,
                        Street = model.Street,
                        House = model.House,
                        Building = model.Building,
                        Flat = model.Flat,
                        Floor = model.Floor,
                        UserId = user.Id,
                        User = user
                    };

                    if (!_adress.GetAllAdresses.Any(a => a.Id == modelAdress.Id))
                        _adress.CreateAdress(modelAdress);

                    else
                        _adress.EditAdress(modelAdress);

                    return RedirectToAction("Index");
                }
            }
        }

        public async Task<IActionResult> UserOrders()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            IEnumerable<OrderViewModel> obj = _appDBContent
                .Orders
                .Include(o => o.User)
                .Include(o => o.Adress)
                .Include(o => o.OrderDetails)
                .Where(o => o.UserId.Equals(user.Id))
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Name = o.User.Name,
                    SurName = o.User.SurName,
                    Adress = o.Adress,
                    DateOrder = o.DateOrder,
                    AllPrice = o.AllPrice,
                    Status = o.Status
                });

            //IEnumerable<Order> obj1 = _allOrders.Orders;

            //IEnumerable<OrderViewModel> obj = _allOrders.Orders
            //    .Where(o => o.UserId.Equals(user.Id))
            //    .Select(o => new OrderViewModel()
            //    {
            //        Id = o.Id,
            //        UserId = o.UserId,
            //        Name = o.User.Name,
            //        SurName = o.User.SurName,
            //        Adress = o.Adress,
            //        DateOrder = o.DateOrder,
            //        AllPrice = o.AllPrice,
            //        Status = o.Status
            //    });

            return View(obj);
        }

        public IActionResult DetailsOrder (int idOrder)
        {
            ViewBag.Title = string.Format("Заказ № {0}", idOrder);

            IEnumerable<DetailOrderViewModel> obj = _appDBContent.OrderDetails
                .Where(o => o.OrderId == idOrder)
                .Include(o => o.Book)
                .Select(o => new DetailOrderViewModel()
                {
                    NameBook = o.Book.NameBook,
                    ImgURL = o.Book.Img,
                    Author = o.Book.Author.NameAuthor,
                    PublishingHouse = o.Book.PublishingHouse,
                    Price = o.Book.Price,
                    Counter = o.Counter
                });

            return View(obj);
        }
    }
}