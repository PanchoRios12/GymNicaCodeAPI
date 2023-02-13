using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCodeAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymNicaCodeAPI.Controllers
{
    /// <summary>
    /// Controller que se encarga de la manipulacion de los roles de usuario
    /// </summary>
    /// Francisco Rios
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolController : ApiControllerBase
    {

        private IRolCommand _rolCommand;
        private IRolQuery _rolQuery;

        public RolController(IRolCommand rolCommand, IRolQuery rolQuery)
        {
            _rolCommand = rolCommand;
            _rolQuery = rolQuery;
        }


        [HttpPost("RolNuevo")]
        public async Task<ActionResult<IdentityRole>> RolNuevo(string Nombre)
        {
            return await _rolCommand.RolNuevo(Nombre);
        }

        [HttpDelete("RolEliminar")]
        public async Task<ActionResult<IdentityRole>> RolEliminar(string Nombre)
        {
            return await _rolCommand.RolEliminar(Nombre);
        }

        [HttpPost("UsuarioRolAgregar")]
        public async Task<ActionResult<IdentityRole>> UsuarioRolAgregar(string userName, string rolName)
        {
            return await _rolCommand.UsuarioRolAgregar(userName, rolName);
        }
        [HttpPost("UsuarioRolEliminar")]
        public async Task<ActionResult<IdentityRole>> UsuarioRolEliminar(string userName, string rolName)
        {
            return await _rolCommand.UsuarioRolEliminar(userName, rolName);
        }
        [HttpGet("ListaRoles")]
        public async Task<ActionResult<List<IdentityRole>>> ListaRoles()
        {
            return await _rolQuery.ListaRoles();
        }
        [HttpGet("{UserName}")]
        public async Task<ActionResult<List<string>>> ObtenerRolesPorUsuario(string UserName)
        {
            return await _rolQuery.ObtenerRolesPorUsuario(UserName);
        }
    }
}
