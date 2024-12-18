using VetClinic.BL.Clients.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.BL.Clients
{
    public interface IClientsManager
    {
        ClientModel CreateClient(CreateClientModel model);
        void DeleteClient(Guid id);
        ClientModel UpdateClient(Guid id, UpdateClientModel model);
    }
}
