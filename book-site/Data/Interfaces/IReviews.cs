using book_site.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Interfaces
{
    public interface IReviews
    {
        public IEnumerable<Reviews> GetAllReviews { get; }
        public Reviews GetReviewsByUser(string UserId);
        public Reviews GetReviewsById(int idReviews);
        public void AddReviews(Reviews reviews);
        public void RemoveReviews(int idReviews);
        public void EditReviews(Reviews reviews);
        public void AddLikeToReviews(int idReviews);
        public void AddDislikeToReviews(int idReviews);
    }
}
