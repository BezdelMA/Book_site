using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class DetailOrderViewModel
    {
        [Display(Name = "Наименование книги")]
        public string NameBook { get; set; }

        [Display(Name = "Изображение")]
        public string ImgURL { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Издательство")]
        public string PublishingHouse { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Количество")]
        public int Counter { get; set; }

        [Display(Name = "Стоимость")]
        public int AllPrice
        {
            get
            {
                return Price * Counter;
            }
            set
            {

            }
        }
    }
}
