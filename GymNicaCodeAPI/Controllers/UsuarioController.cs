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
    public class UsuarioController : ApiControllerBase
    {

        private ILoginCommand _loginCommand;
        private ILoginQuery _loginQuery;

        public UsuarioController(ILoginCommand loginCommand)
        {
            _loginCommand = loginCommand;

        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto user)
        {
            return await _loginCommand.Login(user.Email,user.Password);
        }
        [HttpPost("Registrar")]
        public async Task<ActionResult<UsuarioDto>> Registrar(UsuarioDto usuarioDto)
        {
            return await _loginCommand.Registar(usuarioDto);
        }
        [HttpGet]
        public async Task<ActionResult<UsuarioDto>> DevolverUsuario()
        {
            return await _loginQuery.UsuarioActual();
        }
    }
}
