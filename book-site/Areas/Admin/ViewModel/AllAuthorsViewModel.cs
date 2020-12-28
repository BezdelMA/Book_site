using book_site.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Areas.Admin.ViewModel
{
    public class AllAuthorsViewModel
    {
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Author Author { get; set; }

        [Display(Name = "Автор")]
        public string NameAuthor
        {
            get
            {
                return Author.NameAuthor;
            }
            set
            {

            }
        }

        public IEnumerable<Book> BooksAuthor { get; set; }
    }
}
