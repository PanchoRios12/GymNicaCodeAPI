using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCode.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Query
{
    public class TraduccionQuery : ITraductorQuery
    {
        private readonly ITraduccionService _ITraduccionService;

        public TraduccionQuery(ITraduccionService ItraduccionService)
        {
            _ITraduccionService = ItraduccionService;
        }

        public async Task<TraduccionDto> ObtenerTraduccion(string Llave, string Lang)
        {
            var query = await _ITraduccionService.GetTraduccionPorClaveAsync(Llave, Lang);
            if (query == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe la traducción" });
            }
            return query;
        }
    }
}
