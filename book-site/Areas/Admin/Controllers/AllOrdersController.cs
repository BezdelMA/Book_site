using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using book_site.Areas.Admin.ViewModel;
using book_site.Data;
using book_site.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_site.Areas.Admin.Controllers
{
    [Area(Role.Admin), Authorize(Roles = Role.Admin)]
    public class AllOrdersController : Controller
    {
        private readonly AppDBContent _appDBContent;
        private readonly UserManager<User> _userManager;

        public AllOrdersController(AppDBContent appDBContent, UserManager<User> userManager)
        {
            _appDBContent = appDBContent;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<AllOrdersViewModel> obj = _appDBContent.Orders
                .Include(o => o.User)
                .Include(o => o.Adress)
                .Select(o => new AllOrdersViewModel()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Name = o.User.Name,
                    SurName = o.User.SurName,
                    Adress = o.Adress,
                    PhoneNumber = o.User.PhoneNumber,
                    Email = o.User.Email,
                    DateOrder = o.DateOrder,
                    AllPrice = o.AllPrice,
                    Status = o.Status
                });

            return View(obj);
        }

        public IActionResult AllOrdersWithfilter(string filter)
        {
            IEnumerable<AllOrdersViewModel> obj = _appDBContent.Orders
                .Include(o => o.User)
                .Include(o => o.Adress)
                .Where(o => o.Status.Equals(filter))
                .Select(o => new AllOrdersViewModel()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Name = o.User.Name,
                    SurName = o.User.SurName,
                    Adress = o.Adress,
                    PhoneNumber = o.User.PhoneNumber,
                    Email = o.User.Email,
                    DateOrder = o.DateOrder,
                    AllPrice = o.AllPrice,
                    Status = o.Status
                });

            return View("Index", obj);
        }

        public IActionResult AllOrdersUser(string UserId)
        {
            IEnumerable<AllOrdersViewModel> obj = _appDBContent.Orders
                .Where(o => o.UserId == UserId)
                .Include(o => o.User)
                .Include(o => o.Adress)
                .Select(o => new AllOrdersViewModel()
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    Name = o.User.Name,
                    SurName = o.User.SurName,
                    Adress = o.Adress,
                    PhoneNumber = o.User.PhoneNumber,
                    Email = o.User.Email,
                    DateOrder = o.DateOrder,
                    AllPrice = o.AllPrice,
                    Status = o.Status
                });

            return View("Index", obj);
        }

        public IActionResult OrderDetails(int Id)
        {
            ViewBag.Title = string.Format("Заказ № {0}", Id);

            IEnumerable<OrderDetailsViewModel> obj = _appDBContent.OrderDetails
                .Where(o => o.OrderId == Id)
                .Include(o => o.Book)
                .Select(o => new OrderDetailsViewModel()
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

        public IActionResult Execution(int Id)
        {
            var order = _appDBContent.Orders
                .FirstOrDefault(o => o.Id == Id);
           
            order.Status = "На исполнении";
            _appDBContent.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int Id)
        {
            var order = _appDBContent.Orders
                .FirstOrDefault(o => o.Id == Id);
            
            order.Status = "Выполнен";
            _appDBContent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}