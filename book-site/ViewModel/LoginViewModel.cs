using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnURL { get; set; }
    }
}
