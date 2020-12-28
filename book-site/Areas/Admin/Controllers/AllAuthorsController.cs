using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book_site.Areas.Admin.ViewModel;
using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace book_site.Areas.Admin.Controllers
{
    [Area(Role.Admin), Authorize(Roles = Role.Admin)]
    public class AllAuthorsController : Controller
    {
        private readonly IBooksAuthor authors;
        private readonly IBooks books;

        public AllAuthorsController(IBooksAuthor _authors, IBooks _books)
        {
            authors = _authors;
            books = _books;
        }

        public IActionResult Index()
        {
            IEnumerable<AllAuthorsViewModel> obj = authors.AllAuthors
                .Select(a => new AllAuthorsViewModel()
                {
                    Id = a.Id,
                    Author = a,
                    BooksAuthor = books.AllBooks.Where(b => b.AuthorId == a.Id)
                });
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string nameAuthor)
        {
            authors.AddAuthor(nameAuthor);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var obj = authors.AllAuthors.FirstOrDefault(a => a.Id == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(Author model)
        {
            authors.RemoveAuthor(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var obj = authors.AllAuthors.FirstOrDefault(a => a.Id == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Author model)
        {
            model.NormalizedNameAuthor = model.NameAuthor.ToUpper();
            authors.EditAuthor(model);
            return RedirectToAction("Index");
        }
    }
}