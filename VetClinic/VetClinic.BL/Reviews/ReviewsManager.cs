using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess;
using VetClinic.BL.Reviews.Entities;
using VetClinic.DataAccess.Entities;
namespace VetClinic.BL.Reviews
{
    public class ReviewsManager : IReviewsManager
    {
        private readonly IRepository<ReviewEntity> _reviewsRepository;
        private readonly IMapper _mapper;
        public ReviewsManager(IRepository<ReviewEntity> reviewsRepository, IMapper mapper)
        {
            _reviewsRepository = reviewsRepository;
            _mapper = mapper;
        }

        public ReviewModel CreateReview(CreateReviewModel model)
        {
            var entity = _mapper.Map<ReviewEntity>(model);

            _reviewsRepository.Save(entity);

            return _mapper.Map<ReviewModel>(entity);
        }
        public void DeleteReview(Guid id)
        {
            var entity = _reviewsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Review not found");
            _reviewsRepository.Delete(entity);
        }
        public ReviewModel UpdateReview(Guid id, UpdateReviewModel model)
        {
            var entity = _reviewsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Review not found");
            entity.Description = model.Description;
            entity.DateWriting = model.DateWriting;
            _reviewsRepository.Save(entity);
            return _mapper.Map<ReviewModel>(entity);
        }
    }
}

