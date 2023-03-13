using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Query
{
    public interface IClienteQuery
    {
        Task<List<ClienteDto>> listaClientes();
        Task<ClienteDto> clientePorId(int id);
        Task<PaginationRequestBase<ClienteDto>> clientesPaginado(PaginationDto pagination);
    }
}
