using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess.Entities;
using VetClinic.BL.Reviews.Entities;

namespace VetClinic.BL.Mapper
{
    public class ReviewBLProfile : Profile
    {
        public ReviewBLProfile()
        {
            CreateMap<AdminEntity, ReviewModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateReviewModel, ReviewEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
