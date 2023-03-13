using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Domain;
using GymNicaCode.Services.Validator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Command
{
    public class EmpleadoCommand : IEmpleadoCommand
    {
        private readonly IEmpleadoService _empleadoService;
        /// <summary>
        /// constructor para injectar las dependencias
        /// </summary>
        /// <param name="EmpleadoService">Service de  Empleado</param
        /// Francisco Rios
        public EmpleadoCommand(IEmpleadoService empleadoService)
        {
            _empleadoService= empleadoService;
        }
        public async Task<EmpleadoDto> actualizarEmpleado(EmpleadoDto empleado)
        {
            var query = await _empleadoService.empleadoPorId(empleado.id);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el empleado" });
            }
            var queryUpdate = new EmpleadoDto
            {
                id = empleado.id,
                CodigoEmpleado = empleado.CodigoEmpleado,
                FechaIngreso = empleado.FechaIngreso,
                FechaIngresoString = empleado.FechaIngresoString,
                Nombres = empleado.Nombres,
                Apellidos = empleado.Apellidos,
                Celular = empleado.Celular,
                Cedula = empleado.Cedula,
                Direccion = empleado.Direccion,
                Estado = empleado.Estado

            };
            var valor = await _empleadoService.actualizarEmpleado(queryUpdate);
            if (valor!= null)
            {
                return valor;
            }
            throw new Exception("Error al actualizar");
        }

        public async Task<EmpleadoDto> crearEmpleado(EmpleadoDto empleado)
        {
            EmpleadoValidator validator = new EmpleadoValidator();
            var results = validator.Validate(empleado);
            if (!results.IsValid )
            {
                throw new ValidationException(results.GeneratetDictionary());

            }
            var valor = await _empleadoService.crearEmpleado(empleado);
            if (valor!=null)
            {
                return valor;
            }
            throw new Exception("Error al crear el empleado");
        }
    }
}
