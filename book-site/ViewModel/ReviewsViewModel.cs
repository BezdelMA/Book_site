using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.ViewModel
{
    public class ReviewsViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }

        [Display(Name = "Заголовок")]
        public string TitleReviews { get; set; }

        [Display(Name = "Текст отзыва")]
        public string BodyReviews { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public bool AbilityToDeleteAndEdit { get; set; }
        public DateTime Date { get; set; }
    }
}
