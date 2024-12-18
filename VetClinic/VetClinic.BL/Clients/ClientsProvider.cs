using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.DataAccess;
using VetClinic.BL.Clients.Entities;
using VetClinic.DataAccess.Entities;

namespace VetClinic.BL.Clients
{
    public class ClientsProvider : IClientsProvider
    {
        private readonly IRepository<ClientEntity> _clientRepository;
        private readonly IMapper _mapper;

        public ClientsProvider(IRepository<ClientEntity> clientsRepository, IMapper mapper)
        {
            _clientRepository = clientsRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientModel> GetClients(ClientModelFilter modelFilter = null)
        {
            var nameclient = modelFilter.NameClient;
            var phoneNumber = modelFilter.PhoneNumber;
            var email = modelFilter.Email;
            var clients = _clientRepository.GetAll(x =>
            (nameclient == null || nameclient == x.NameClient) &&
            (phoneNumber == null || phoneNumber == x.PhoneNumber) &&
            (email==null || email==x.Email));


            return _mapper.Map<IEnumerable<ClientModel>>(clients);
        }

        public ClientModel GetClientInfo(Guid id)
        {
            var client = _clientRepository.GetById(id);
            if (client is null)
                throw new ArgumentException("Client not found.");

            return _mapper.Map<ClientModel>(client);
        }
    }
}
