using FluentValidation;
using GymNicaCode.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Services.Validator
{
    public class EmpleadoValidator : AbstractValidator<EmpleadoDto>
    {
        public EmpleadoValidator()
        {
            RuleFor(x => x.CodigoEmpleado).NotEmpty();
            RuleFor(x => x.FechaIngreso).NotEmpty();
            RuleFor(x => x.Nombres).NotEmpty();
            RuleFor(x => x.Apellidos).NotEmpty();
            RuleFor(x => x.Cedula).NotEmpty();
            RuleFor(x => x.Celular).NotEmpty();
            RuleFor(x => x.Direccion).NotEmpty();
        }
    }
}
