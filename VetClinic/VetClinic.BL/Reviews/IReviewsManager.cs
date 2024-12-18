using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Reviews.Entities;
namespace VetClinic.BL.Reviews
{
    public interface IReviewsManager
    {
        ReviewModel CreateReview(CreateReviewModel model);
        void DeleteReview(Guid id);
        ReviewModel UpdateReview(Guid id, UpdateReviewModel model);
    }
}
