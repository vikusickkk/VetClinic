using AutoMapper;
using VetClinic.BL.Admins.Entities;
using VetClinic.WebAPI.Controllers.Entities;

namespace VetClinic.WebAPI.Mapper
{
    public class AdminsWebAPIProfile : Profile
    {
        public AdminsWebAPIProfile()
        {
            CreateMap<AdminsFilter, AdminModelFilter>();
            CreateMap<CreateAdminRequest, CreateAdminModel>();
            CreateMap<UpdateAdminRequest, UpdateAdminModel>();
        }
    }
}
