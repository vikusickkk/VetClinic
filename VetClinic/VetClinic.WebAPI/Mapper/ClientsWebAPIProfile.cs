using AutoMapper;
using VetClinic.BL.Clients.Entities;
using VetClinic.WebAPI.Controllers.Entities;

namespace VetClinic.WebAPI.Mapper
{
    public class ClientsWebAPIProfile : Profile
    {
        public ClientsWebAPIProfile()
        {
            CreateMap<ClientsFilter, ClientModelFilter>();
            CreateMap<CreateClientRequest, CreateClientModel>();
            CreateMap<UpdateClientRequest, UpdateClientModel>();
        }
    }
}
