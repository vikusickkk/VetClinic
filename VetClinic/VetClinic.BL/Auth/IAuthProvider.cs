using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.BL.Auth.Entities;

namespace VetClinic.BL.Auth
{
    public interface IAuthProvider
    {
        Task<TokensResponse> AuthorizeClient(string email, string password);
        Task RegisterClient (string email, string password);
    }
}
