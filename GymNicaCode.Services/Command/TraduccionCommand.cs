using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GymNicaCode.Services.Validator;

namespace GymNicaCode.Services.Command
{
    public class TraduccionCommand : ITraductorCommand
    {
        private readonly ITraduccionService _ITraduccionService;

        public TraduccionCommand(ITraduccionService ItraduccionService)
        {
            _ITraduccionService = ItraduccionService;
        }

        public async Task<TraduccionDto> CrearTraduccion(TraduccionDto query)
        {
            TraductorValidator validator = new TraductorValidator();
            var results = validator.Validate(query);

            if (!results.IsValid)
            {
                throw new Application.Exceptions.ValidationException(results.GeneratetDictionary());
            }

            var valor = await _ITraduccionService.AddTraduccionAsync(query);
            if (valor != null)
            {
                query.Id = valor.Id;
                return query;
            }

            throw new Exception("No se pudo crear el tipo persona");
        }
    }
}
