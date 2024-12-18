using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duende.IdentityServer.Models;
using VetClinic.BL.Auth.Entities;
using VetClinic.DataAccess.Entities;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;
namespace VetClinic.BL.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private readonly SignInManager<ClientEntity> _signInManager;
        private readonly UserManager<ClientEntity> _clientManager;
        private readonly string _identityServerUri;
        private readonly string _clientId;
        private readonly string _clientSecret;

        public AuthProvider(SignInManager<ClientEntity> signInManager, UserManager<ClientEntity> clientManager,
            string identityServerUri,
            string clientId,
            string clientSecret)
        {
            _signInManager = signInManager;
            _clientManager = clientManager;
            _identityServerUri = identityServerUri;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<TokensResponse> AuthorizeClient(string email, string password)
        {
            var client = await _clientManager.FindByEmailAsync(email); //IRepository<UserEntity> get user by email
            if (client is null)
            {
                throw new Exception(); //UserNotFoundException, BusinessLogicException(Code.UserNotFound);
            }


            var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(client, password, false);
            if (!verificationPasswordResult.Succeeded)
            {
                throw new Exception(); //AuthorizationException, BusinessLogicException(Code.PasswordOrLoginIsIncorrect);
            }

            var client_ = new HttpClient();
            var discoveryDoc = await client_.GetDiscoveryDocumentAsync(_identityServerUri); //
            if (discoveryDoc.IsError)
            {
                throw new Exception();
            }

            var tokenResponse = await client_.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = discoveryDoc.TokenEndpoint,
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                UserName = client.NameClient,
                Password = password,
                Scope = "api offline_access"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception();
            }

            return new TokensResponse()
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };
        }

        public async Task RegisterClient(string email, string password)
        {
            ClientEntity clientEntity = new ClientEntity()
            {
                Email = email,
                NameClient = email
            };

            var createClientResult = await _clientManager.CreateAsync(clientEntity, password);

        }
    }
}
