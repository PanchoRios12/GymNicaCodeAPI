using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Security;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCode.Domain;
using GymNicaCode.Persistence.Connection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Query
{
    public class LoginQuery : ILoginQuery
    {
        #region "Variables Globales"
        private readonly UserManager<Usuario> userManager;
        private readonly IConexion context;
        private readonly IUsuarioHelper _usuarioSesion;
        private readonly IJwtGenerador _jwtGenerador;
        #endregion


        public LoginQuery(UserManager<Usuario> _userManager, IConexion _context, IUsuarioHelper usuarioSesion, IJwtGenerador jwtGenerador)
        {
            userManager = _userManager;
            context = _context;
            _usuarioSesion = usuarioSesion;
            _jwtGenerador = jwtGenerador;
        }
        /// <summary>
        /// Metodo que  obtiene los roles por usuario
        /// </summary>
        public async Task<List<string>> ObtenerRolesPorUsuario(string userName)
        {
            var usuarioIden = await userManager.FindByNameAsync(userName);
            if (usuarioIden == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No existe el Usuario" });
            }

            var resultado = await userManager.GetRolesAsync(usuarioIden);
            return new List<string>(resultado);

        }

        /// <summary>
        /// Metodo que obtiene el usuario actual
        /// </summary>
        public async Task<UsuarioDto> UsuarioActual()
        {
            var usuario = await userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

            var resultadoRoles = await userManager.GetRolesAsync(usuario);
            var listaRoles = new List<string>(resultadoRoles);

            return new UsuarioDto
            {
                NombreCompleto = usuario.NombreCompleto,
                UserName = usuario.UserName,
                Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                Imagen = null,
                Email = usuario.Email
            };
        }
    }
}
