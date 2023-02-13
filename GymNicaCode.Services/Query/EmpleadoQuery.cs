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
    public class EmpleadoQuery : IEmpleadoQuery
    {
        private readonly IEmpleadoService _empleadoService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="_context">Contexto Base</param>
        /// <param name="_empleadoService">Service de empleado</param>
        /// Francisco Rios
        public EmpleadoQuery (IEmpleadoService empleadoService)
        {
            _empleadoService= empleadoService;
        }
        public async Task<EmpleadoDto> empleadoPorId(int idEmpleado)
        {
            var query = await _empleadoService.empleadoPorId(idEmpleado);
            if (query==null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el empleado" });
            }
            return query;
        }

        public async Task<List<EmpleadoDto>> listaEmpleado()
        {
           var query =await _empleadoService.listaEmpleado();
           return query.ToList();
        }

        public Task<PaginationRequestBase<EmpleadoDto>> listaEmpleadoPaginado(PaginationDto pagination)
        {
            var query = _empleadoService.listaEmpleadoPaginado(pagination);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el empleado" });
            }
            return query;
        }
    }
}
