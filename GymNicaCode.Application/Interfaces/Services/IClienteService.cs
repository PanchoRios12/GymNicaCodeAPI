using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services
{
    
    public interface IClienteService
    {
        /// <summary>
        /// Agrega un nuevo cliente 
        /// </summary>
        /// <param name="Cliente">empleado</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<ClienteDto> crearCliente (ClienteDto cliente);
        /// <summary>
        /// Actualiza a un cliente
        /// </summary>
        /// <param name="cliente">Empleado</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<ClienteDto> actualizarCliente (ClienteDto cliente);
        /// <summary>
        /// Obtiene todos los cliente
        /// </summary>
        /// <returns>Obtiene todos los cliente</returns>
        /// Francisco Rios
        Task<List<ClienteDto>> listaCliente ();
        /// <summary>
        /// Obtiene un cliente por Id
        /// </summary>
        /// <param name="IdCliente">IdEmpleado</param>
        /// <returns>Retorna un cliente</returns>
        /// Francisco Rios
        Task<ClienteDto> ClientePorId(int idCliente);
        /// <summary>
        /// Obtiene los cliente paginados
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna los clientes paginados</returns>
        /// Francisco Rios
        Task<PaginationRequestBase<ClienteDto>> listaClientePaginado(PaginationDto pagination);
    }
}
