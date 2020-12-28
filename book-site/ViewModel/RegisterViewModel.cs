using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Обязательное поле для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare(nameof(Password), ErrorMessage ="Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
