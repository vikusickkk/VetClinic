using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Reviews.Entities;
namespace VetClinic.BL.Reviews
{
    public interface IReviewsProvider
    {
        IEnumerable<ReviewModel> GetReviews(ReviewModelFilter modelFilter = null);
        ReviewModel GetReviewInfo(Guid id);
    }
}
