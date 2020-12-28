using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public string NormalizedNameBook { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public string Annotation { get; set; }
        public string Img { get; set; }
        public string PublishingHouse { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public int Year { get; set; }
        public bool IsNew { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsStock { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public string Mark {
            get
            {
                if (IsNew)
                    return "Новинка";
                else if (IsStock)
                    return "Акция";
                else if (IsFavorite)
                    return "Популярная";
                else return "";
            }
        }
    }
}
