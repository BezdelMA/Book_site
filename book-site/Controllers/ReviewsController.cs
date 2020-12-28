using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using book_site.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace book_site.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviews _reviews;
        private readonly UserManager<User> _userManager;

        public ReviewsController(IReviews reviews, UserManager<User> userManager)
        {
            _reviews = reviews;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List <ReviewsViewModel> obj = _reviews.GetAllReviews.Select(r => new ReviewsViewModel
            {
                Id = r.Id,
                User = r.User,
                UserName = r.User.Name,//string.Format("{0} {1}", r.User.SurName, r.User.Name),
                TitleReviews = r.TitleReviews,
                BodyReviews = r.BodyReviews,
                Like = r.Like,
                Dislike = r.Dislike,
                Date = r.DateReviews
            }).ToList();

            var _user = new User();

            if (User.Identity.IsAuthenticated)
            {
                _user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            foreach (var item in obj)
            {
                if (item.User == _user)
                    item.AbilityToDeleteAndEdit = true;

                else
                    item.AbilityToDeleteAndEdit = false;

                if (string.IsNullOrEmpty(item.UserName))
                    item.UserName = "Неизвестный";
            }

            return View(obj);
        }

        [Authorize]
        public IActionResult AddReviews()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReviews(ReviewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User();

            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            Reviews reviews = new Reviews();
            reviews.User = user;
            reviews.UserId = user.Id;
            reviews.TitleReviews = model.TitleReviews;
            reviews.BodyReviews = model.BodyReviews;
            reviews.DateReviews = DateTime.Now;

            _reviews.AddReviews(reviews);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteReviews(int idReviews)
        {
            _reviews.RemoveReviews(idReviews);
            return RedirectToAction("Index");
        }
    }
}