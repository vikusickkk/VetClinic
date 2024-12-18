using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Admins.Entities;
using VetClinic.DataAccess.Entities;

namespace VetClinic.BL.Mapper
{
    public class AdminBLProfile : Profile
    {
        public AdminBLProfile()
        {
            CreateMap<AdminEntity, AdminModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateAdminModel, AdminEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
