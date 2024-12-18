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
    public class ClientsManager : IClientsManager
    {
        private readonly IRepository<ClientEntity> _clientsRepository;
        private readonly IMapper _mapper;
        public ClientsManager(IRepository<ClientEntity> clientsRepository, IMapper mapper)
        {
            _clientsRepository = clientsRepository;
            _mapper = mapper;
        }

        public ClientModel CreateClient(CreateClientModel model)
        {
            var entity = _mapper.Map<ClientEntity>(model);

            _clientsRepository.Save(entity);

            return _mapper.Map<ClientModel>(entity);
        }
        public void DeleteClient(Guid id)
        {
            var entity = _clientsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Client not found");
            _clientsRepository.Delete(entity);
        }
        public ClientModel UpdateClient(Guid id, UpdateClientModel model)
        {
            var entity = _clientsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException(" not found");
            entity.PasswordHash = model.PasswordHash;
            entity.NameClient = model.NameClient;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            _clientsRepository.Save(entity);
            return _mapper.Map<ClientModel>(entity);
        }

    }
}
