using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCodeAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymNicaCodeAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class TraduccionController : ApiControllerBase
    {
        private ITraductorCommand _traductorCommand;
        private ITraductorQuery _traductorQuery;

        public TraduccionController(ITraductorCommand traductorCommand, ITraductorQuery traductorQuery)
        {
            _traductorCommand = traductorCommand;
            _traductorQuery = traductorQuery;
        }

        [HttpPost("CrearTraduccion")]
        public async Task<ActionResult<TraduccionDto>> CreateTipoPersona(TraduccionDto parametros)
        {
            return await _traductorCommand.CrearTraduccion(parametros);
        }

        [HttpGet("ObtenerTraduccion/{llave}/{lang}")]
        public async Task<ActionResult<TraduccionDto>> GetTraduccionXClave(string llave, string lang)
        {
            return await _traductorQuery.ObtenerTraduccion(llave, lang);
        }
    }
}
