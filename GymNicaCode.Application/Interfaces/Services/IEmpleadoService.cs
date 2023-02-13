using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services
{
    public interface IEmpleadoService
    {
        /// <summary>
        /// Agrega un nuevo empleado 
        /// </summary>
        /// <param name="empleado">empleado</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<EmpleadoDto> crearEmpleado(EmpleadoDto empleado);
        /// <summary>
        /// Actualiza a un empleado
        /// </summary>
        /// <param name="Empleado">Empleado</param>
        /// <returns></returns>
        /// Francisco Rios
        Task<EmpleadoDto> actualizarEmpleado(EmpleadoDto empleado);
        /// <summary>
        /// Obtiene todos los empleado
        /// </summary>
        /// <returns>Obtiene todos los empleado</returns>
        /// Francisco Rios
        Task<List<EmpleadoDto>> listaEmpleado();
        /// <summary>
        /// Obtiene un empleado por Id
        /// </summary>
        /// <param name="IdEmpleado">IdEmpleado</param>
        /// <returns>Retorna un empleado</returns>
        /// Francisco Rios
        Task<EmpleadoDto> empleadoPorId(int idEmpleado);
        /// <summary>
        /// Obtiene los empleados paginados
        /// </summary>
        /// <param name="pagination">Objeto con los datos de paginacion</param>
        /// <returns>Retorna los empleados paginados</returns>
        /// Francisco Rios
        Task<PaginationRequestBase<EmpleadoDto>> listaEmpleadoPaginado(PaginationDto pagination);

    }
}
