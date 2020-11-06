using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        [Display(Name ="Имя")]
        [Required(ErrorMessage = "Имя является обязательным полем")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени 2 символа")]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия является обязательным полем")]
        [MinLength(2, ErrorMessage = "Минимальная длина фамилии 2 символа")]
        public string SurName { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Адрес является обязательным полем")]
        public string Adress { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Телефон является обязательным полем")]
        [MinLength(2, ErrorMessage = "Минимальная длина номера тлефона 10 символов")]
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime DateOrder { get; set; }
        
        public List<OrderDetails> OrderDetails { get; set; }

    }
}
