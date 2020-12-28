using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string TitleReviews { get; set; }
        public string BodyReviews { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public DateTime DateReviews { get; set; }
        public DateTime DateEditReviews { get; set; }
    }
}
