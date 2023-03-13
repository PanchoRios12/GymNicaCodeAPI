using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Services.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Command
{
    public class ClienteCommand : IClienteCommand
    {
        private readonly IClienteService _clienteServices;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="ClienteService">Service de  Cliente</param
        /// Francisco Rios
        public ClienteCommand(IClienteService clienteService)
        {
            _clienteServices = clienteService;
        }
        public async Task<ClienteDto> crearCliente(ClienteDto cliente)
        {
            ClienteValidator validator = new ClienteValidator();
            var result =validator.Validate(cliente);
            if (!result.IsValid)
            {
                throw new ValidationException(result.GeneratetDictionary());
            }
            var valor =  await _clienteServices.crearCliente(cliente);
            if (validator != null)
            {
                return valor;
            }
            throw new Exception("Error al crear el cliente");
        }

        public async Task<ClienteDto> actualizarCliente(ClienteDto cliente)
        {
            var result = await _clienteServices.ClientePorId(cliente.id);
            if (result == null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el cliente" });

            }
            var resultUpdate = new ClienteDto
            {
                id= cliente.id,
                NombresCliente= cliente.NombresCliente,
                ApellidosCliente  = cliente.ApellidosCliente,
                NoCelular= cliente.NoCelular,
                Correo= cliente.Correo,
                Cedula= cliente.Cedula,
                FotoCliente= cliente.FotoCliente,
                ClaveDeAcceso =cliente.ClaveDeAcceso,
               Estado= cliente.Estado,
            };
            var valor = await _clienteServices.actualizarCliente(resultUpdate);
            if (valor!=null)
            {
                return valor;
            }
            throw new Exception("Error al actualizar");
        }
    }
}
