using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using book_site.Data.Models;
using book_site.Data;
using book_site.Areas.Admin.ViewModel;
using book_site.Data.Interfaces;

namespace book_site.Areas.Admin.Controllers
{
    [Area(Role.Admin), Authorize(Roles = Role.Admin)]
    public class HomeController : Controller
    {
        private readonly AppDBContent _appDBContent;
        private readonly IBooks _books;
        private readonly IBooksAuthor _author;
        private readonly IBooksGenre _genre;

        public HomeController(AppDBContent appDBContent, IBooks books, IBooksAuthor author, IBooksGenre genre)
        {
            _appDBContent = appDBContent;
            _books = books;
            _author = author;
            _genre = genre;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}