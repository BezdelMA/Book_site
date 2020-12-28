using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [Required]
        public string SurName { get; set; }

        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Номер телефона")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Страна")]
        [Required]
        public string Country { get; set; }

        [Display(Name = "Город")]
        [Required]
        public string City { get; set; }

        [Display(Name = "Улица")]
        [Required]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        [Required]
        public int House { get; set; }

        [Display(Name = "Строение/Корпус")]
        public int Building { get; set; }

        [Display(Name = "Квартира")]
        [Required]
        public int Flat { get; set; }

        [Display(Name = "Этаж")]
        public int Floor { get; set; }
        public string UserId { get; set; }
        public int AdressId { get; set; }
    }
}
