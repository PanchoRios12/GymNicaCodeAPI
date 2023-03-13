using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Application.Interfaces.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Query
{
    public class ClienteQuery:IClienteQuery
    {
        private readonly IClienteService _clienteService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_context">Contexto Base</param>
        /// <param name="_clienteService">Service de cliente</param>
        /// Francisco Rios
        public ClienteQuery(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ClienteDto> clientePorId(int id)
        {
           var result =    await _clienteService.ClientePorId(id);
            if (result==null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "no existe el cliente" });
            }
            return result;
        }

        public async Task<PaginationRequestBase<ClienteDto>> clientesPaginado(PaginationDto pagination)
        {
           var result =await _clienteService.listaClientePaginado(pagination);
            if (result==null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el cliente" });
            }
            return result;
        }

        public async Task<List<ClienteDto>> listaClientes()
        {
            var result = await _clienteService.listaCliente();
            return result;
        }
    }
}
