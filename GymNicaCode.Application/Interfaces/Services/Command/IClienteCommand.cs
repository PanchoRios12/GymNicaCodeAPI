using GymNicaCode.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Command
{
    public interface IClienteCommand
    {
        Task<ClienteDto> crearCliente(ClienteDto cliente);
        Task<ClienteDto> actualizarCliente(ClienteDto cliente);
    }
}
