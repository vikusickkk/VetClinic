using VetClinic.BL.Clients.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.BL.Clients
{
    public interface IClientsProvider
    {
        IEnumerable<ClientModel> GetClients(ClientModelFilter modelFilter = null);
        ClientModel GetClientInfo(Guid id);
    }
}
