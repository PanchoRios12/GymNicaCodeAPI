using FluentValidation;
using GymNicaCode.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Validator
{
    public class ClienteValidator : AbstractValidator<ClienteDto>
    {
        public ClienteValidator() 
        {
            RuleFor(x => x.CodigoCliente).NotEmpty();
            RuleFor(x => x.NombresCliente).NotEmpty();
            RuleFor(x => x.ApellidosCliente).NotEmpty();
            RuleFor(x => x.Cedula).NotEmpty();
            RuleFor(x => x.NoCelular).NotEmpty();
            RuleFor(x => x.Correo).NotEmpty();
        }
    }
}
