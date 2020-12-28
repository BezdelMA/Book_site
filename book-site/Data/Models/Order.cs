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

        public string UserId { get; set; }
        public User User { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public DateTime DateOrder { get; set; }
        public string Status { get; set; }
        public int AllPrice { get; set; }
        
        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
