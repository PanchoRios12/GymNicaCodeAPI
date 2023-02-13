using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCodeAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymNicaCodeAPI.Controllers
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de tipo persona
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpleadoController : ApiControllerBase
    {

        private IEmpleadoCommand _empleadoCommand;
        private IEmpleadoQuery _empleadoQuery;
        public EmpleadoController(IEmpleadoCommand empleadoCommand, IEmpleadoQuery empleadoQuery)
        {
            _empleadoCommand = empleadoCommand;
            _empleadoQuery = empleadoQuery;
        }
        /// <summary>
        /// EndPoint encargado de crear un nuevo empleado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/empleado/CrearEmpleado
        [HttpPost("CrearEmpleado")]
        public async Task<ActionResult<EmpleadoDto>> crearEmpleado(EmpleadoDto parametros)
        {
            return await _empleadoCommand.crearEmpleado(parametros);
        }
        /// <summary>
        /// EndPoint encargado de Editar un empleado
        /// </summary>
        /// <param name="parametros">Parametros para mediador</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/empleado/actualizarEmpleado
        [HttpPut("actualizarEmpleado")]
        public async Task<ActionResult<EmpleadoDto>> actualizarEmpleado(EmpleadoDto parametros)
        {
            return await _empleadoCommand.actualizarEmpleado(parametros);
        }
        /// <summary>
        /// EndPoint encargado de listar  los empleado
        /// </summary>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/empleado/listaEmpleado
        [HttpGet("ListaEmpleado")]
        public async Task<ActionResult<List<EmpleadoDto>>> listaEmpleado()
        {
            return await _empleadoQuery.listaEmpleado();
        }
        /// <summary>
        /// EndPoint encargado de buscar un empleado por Id
        /// </summary>
        /// <param name="id">IdEmpleado</param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/empleado/obtenerEmpleadoPorId/Id
        [HttpGet("obtenerEmpleadoPorId/{id}")]
        public async Task<ActionResult<EmpleadoDto>> obtenerEmpleadoPorId(int id)
        {
            return await _empleadoQuery.empleadoPorId(id);
        }
        /// <summary>
        /// EndPoint encargado de listar Empleado paginado
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        /// <remarks>Francisco Rios</remarks>
        // /api/empleado/obtenerEmpleadoPaginado
        [HttpPost("obtenerEmpleadoPaginado")]
        public async Task<ActionResult<PaginationRequestBase<EmpleadoDto>>> listaEmpleadoPaginado(PaginationDto pagination)
        {
            return await _empleadoQuery.listaEmpleadoPaginado(pagination);
        }
    }
}
