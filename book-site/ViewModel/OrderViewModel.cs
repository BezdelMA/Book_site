using book_site.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class OrderViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }

        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        
        [Display(Name = "Заказчик")]
        public string User
        {
            get
            {
                return string.Format("{0} {1}", SurName, Name);
            }
            set { }
        }

        [Display(Name = "Адрес")]
        public Adress Adress { get; set; }

        [Display(Name = "Адрес доставки")]
        public string AdressString
        {
            get
            {
                return string.Format("г. {0}, ул. {1}, д. {2}, к. {3}, кв. {4}, эт. {5}", Adress.City, Adress.Street, Adress.House, Adress.Building, Adress.Flat, Adress.Floor);
            }
            set { }
        }

        [Display(Name = "Дата заказа")]
        public DateTime DateOrder { get; set; }

        [Display(Name = "Стоимость")]
        public int AllPrice { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
