using book_site.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Areas.Admin.ViewModel
{
    public class AllProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Наименование книги")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public string NameBook { get; set; }

        [Display(Name = "Имя автора")]
        public string Author { get; set; }

        [Display(Name = "Наименование жанра")]
        public string Genre { get; set; }

        [Display(Name = "Аннотация")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public string Annotation { get; set; }

        [Display(Name = "Картинка")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public IFormFile ImgFile { get; set; }

        [Display(Name = "Картинка")]
        public string Img { get; set; }

        [Display(Name = "Издательство")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public string PublishingHouse { get; set; }

        [Display(Name = "Цена книги")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public int Price { get; set; }

        [Display(Name = "Год издания")]
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        public int Year { get; set; }

        [Display(Name = "Новинка")]
        public bool IsNew { get; set; }

        [Display(Name = "Популярная")]
        public bool IsFavorite { get; set; }

        [Display(Name = "Акция")]
        public bool IsStock { get; set; }

        public IEnumerable<AllProductViewModel> AllProducts { get; set; }

        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
