using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCode.Services.Query;
using GymNicaCodeAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymNicaCodeAPI.Controllers
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de Cliente
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ApiControllerBase
    {

        private IClienteCommand _clienteCommand;
        private IClienteQuery _clienteQuery;


        public ClienteController(IClienteCommand clienteCommand, IClienteQuery clienteQuery)
        {
            _clienteCommand = clienteCommand;
            _clienteQuery = clienteQuery;
        }
        /// <summary>
        /// EndPoint encargado de crear un nuevo Cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/cliente/Crearcliente
        [HttpPost("Crearcliente")]
        public async Task<ActionResult<ClienteDto>> crearCliente(ClienteDto parametro)
        {
            return await _clienteCommand.crearCliente(parametro);
        }
        /// <summary>
        /// EndPoint encargado de Editar un cliente
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/cliente/actualizarCliente
        [HttpPut("actualizarCliente")]
        public async Task<ActionResult<ClienteDto>> actualizarCliente(ClienteDto parametros)
        {
            return await _clienteCommand.actualizarCliente(parametros);
        }
        /// <summary>
        /// EndPoint encargado de listar  los cliente
        /// </summary>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/cliente/listaCliente
        [HttpGet("listaCliente")]
        public async Task<ActionResult<List<ClienteDto>>> listaCliente()
        {
            return await _clienteQuery.listaClientes();
        }
        /// <summary>
        /// EndPoint encargado de buscar un cliente por Id
        /// </summary>
        /// <param name="id">IdCliente</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/cliente/obtenerClientePorId/Id
        [HttpGet("obtenerClientePorId/{id}")]
        public async Task<ActionResult<ClienteDto>> obtenerClientePorId(int id)
        {
            return await _clienteQuery.clientePorId(id);
        }
        /// <summary>
        /// EndPoint encargado de listar cliente paginado
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/cliente/obtenerClientePaginado
        [HttpPost("obtenerClientePaginado")]
        public async Task<ActionResult<PaginationRequestBase<ClienteDto>>> clientesPaginado(PaginationDto pagination)
        {
            return await _clienteQuery.clientesPaginado(pagination);
        }
    }
}
