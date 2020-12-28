using book_site.Data.Interfaces;
using book_site.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_site.Data.Repository
{
    public class ReviewsRepository : IReviews
    {
        private readonly AppDBContent appDBContent;

        public ReviewsRepository(AppDBContent _appDBContent) => appDBContent = _appDBContent;

        public IEnumerable<Reviews> GetAllReviews => appDBContent.Reviews.Include(r => r.User);

        public Reviews GetReviewsByUser(string UserId)
        {
            return appDBContent.Reviews.FirstOrDefault(r => r.UserId.Equals(UserId));
        }
        public Reviews GetReviewsById(int idReviews)
        {
            return appDBContent.Reviews.FirstOrDefault(r => r.Id == idReviews);
        }
        public void AddDislikeToReviews(int idReviews)
        {
            Reviews reviews = GetReviewsById(idReviews);
            reviews.Dislike += 1;
            appDBContent.Update(reviews);
            appDBContent.SaveChanges();
        }

        public void AddLikeToReviews(int idReviews)
        {
            Reviews reviews = GetReviewsById(idReviews);
            reviews.Like += 1;
            appDBContent.Update(reviews);
            appDBContent.SaveChanges();
        }

        public void AddReviews(Reviews reviews)
        {
            if (reviews != null)
            {
                appDBContent.Reviews.Add(reviews);
                appDBContent.SaveChanges();
            }
        }

        public void EditReviews(Reviews reviews)
        {
            Reviews _reviews = GetReviewsById(reviews.Id);
            _reviews = reviews;
            appDBContent.Reviews.Update(_reviews);
            appDBContent.SaveChanges();
        }

        public void RemoveReviews(int idReviews)
        {
            Reviews reviews = appDBContent.Reviews.FirstOrDefault(r => r.Id == idReviews);
            appDBContent.Reviews.Remove(reviews);
            appDBContent.SaveChanges();
        }
    }
}
