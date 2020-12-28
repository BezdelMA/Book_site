using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Areas.Admin.ViewModel
{
    public class AllOrdersViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string User
        {
            get
            {
                return string.Format("{0} {1}", SurName, Name);
            }
            set { }
        }

        public Adress Adress { get; set; }

        public string AdressString 
        { 
            get
            {
                return string.Format("г. {0}, ул. {1}, д. {2}, к. {3}, кв. {4}, эт. {5}", Adress.City, Adress.Street, Adress.House, Adress.Building, Adress.Flat, Adress.Floor);
            }
            set { }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOrder { get; set; }
        public int AllPrice { get; set; }
        public string Status { get; set; }
    }
}
