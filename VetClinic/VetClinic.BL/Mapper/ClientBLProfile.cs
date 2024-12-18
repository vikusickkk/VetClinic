using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess.Entities;
using VetClinic.BL.Clients.Entities;
namespace VetClinic.BL.Mapper
{
    public class ClientBLProfile : Profile
    {
        public ClientBLProfile()
        {
            CreateMap<AdminEntity, ClientModel>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.ExternalId));

            CreateMap<CreateClientModel, ClientEntity>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ExternalId, y => y.Ignore())
                .ForMember(x => x.ModificationTime, y => y.Ignore())
                .ForMember(x => x.CreationTime, y => y.Ignore());
        }
    }
}
