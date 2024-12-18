using VetClinic.BL.Reviews.Entities;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace VetClinic.BL.Reviews
{
    public class ReviewsProvider : IReviewsProvider
    {
        private readonly IRepository<ReviewEntity> _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewsProvider(IRepository<ReviewEntity> reviewsRepository, IMapper mapper)
        {
            _reviewRepository = reviewsRepository;
            _mapper = mapper;
        }

        public IEnumerable<ReviewModel> GetReviews(ReviewModelFilter modelFilter = null)
        {
            var clientId = modelFilter.ClientID;
            var datewriting = modelFilter.DateWriting;
            var reviews = _reviewRepository.GetAll(x =>
            (clientId == null || clientId == x.ClientID) &&
            (datewriting == null || datewriting == x.DateWriting));


            return _mapper.Map<IEnumerable<ReviewModel>>(reviews);
        }

        public ReviewModel GetReviewInfo(Guid id)
        {
            var review = _reviewRepository.GetById(id);
            if (review is null)
                throw new ArgumentException("Review not found.");

            return _mapper.Map<ReviewModel>(review);
        }
    }
}

