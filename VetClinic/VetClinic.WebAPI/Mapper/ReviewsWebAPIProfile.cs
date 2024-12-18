using AutoMapper;
using VetClinic.BL.Reviews.Entities;
using VetClinic.WebAPI.Controllers.Entities;

namespace VetClinic.WebAPI.Mapper
{
    public class ReviewsWebAPIProfile : Profile
    {
        public ReviewsWebAPIProfile()
        {
            CreateMap<ReviewsFilter, ReviewModelFilter>();
            CreateMap<CreateReviewRequest, CreateReviewModel>();
            CreateMap<UpdateReviewRequest, UpdateReviewModel>();
        }
    }
}
