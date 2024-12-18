using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.BL.Clients;
using VetClinic.BL.Clients.Entities;
using VetClinic.WebAPI.Controllers.Entities;
namespace VetClinic.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientsProvider _clientsProvider;
        private readonly IClientsManager _clientsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ClientController(IClientsProvider productsProvider, IClientsManager productsManager, IMapper mapper, ILogger logger)
        {
            _clientsManager = productsManager;
            _clientsProvider = productsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //clients/
        public IActionResult GetAllClients()
        {
            var clients = _clientsProvider.GetClients();
            return Ok(new ClientsListResponce()
            {
                Clients = clients.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] 
        public IActionResult GetFilteredClients([FromQuery] ClientsFilter filter)
        {
            var clients = _clientsProvider.GetClients(_mapper.Map<ClientModelFilter>(filter));
            return Ok(new ClientsListResponce()
            {
                Clients = clients.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //clients/{id}
        public IActionResult GetClientInfo([FromRoute] Guid id)
        {
            try
            {
                var client = _clientsProvider.GetClientInfo(id);
                return Ok(client);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] CreateClientRequest request)
        {
            try
            {
                var client = _clientsManager.CreateClient(_mapper.Map<CreateClientModel>(request));
                return Ok(client);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateClientInfo([FromRoute] Guid id, UpdateClientRequest request)
        {
            try
            {
                var client = _clientsManager.UpdateClient(id, _mapper.Map<UpdateClientModel>(request));
                return Ok(client);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteClient([FromRoute] Guid id)
        {
            try
            {
                _clientsManager.DeleteClient(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }
}
