using GymNicaCode.Application.Exceptions;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Command
{
    public class RolCommand : IRolCommand
    {
        #region "Variables Globales"
        private readonly RoleManager<IdentityRole> rolManager;
        private readonly UserManager<Usuario> userManager;
        #endregion

        public RolCommand(UserManager<Usuario> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            rolManager = _roleManager;
        }
        /// <summary>
        /// Metodo que sirve para crear un rol nuevo
        /// </summary>
        public async Task<IdentityRole> RolNuevo(string Nombre)
        {
            var rol = await rolManager.FindByNameAsync(Nombre);
            if (rol != null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Ya existe el Rol" });
            }
            var resultado = await rolManager.CreateAsync(new IdentityRole(Nombre));
            if (resultado.Succeeded)
            {
                return new IdentityRole
                {
                };
            }
            throw new Exception("No se pudo crear el Rol");
        }
        /// <summary>
        /// Metodo que sirve para eliminar un rol
        /// </summary>
        public async Task<IdentityRole> RolEliminar(string Nombre)
        {
            var rol = await rolManager.FindByNameAsync(Nombre);
            if (rol == null)
            {
                throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "No existe Rol" });
            }
            var resultado = await rolManager.DeleteAsync(rol);
            if (resultado.Succeeded)
            {
                return new IdentityRole
                {
                };
            }
            throw new Exception("No se pudo eliminar el Rol");
        }
        /// <summary>
        /// Metodo que sirve para agregar un rol a un usuario
        /// </summary>
        public async Task<IdentityRole> UsuarioRolAgregar(string userName, string rolName)
        {
            var role = await rolManager.FindByNameAsync(rolName);
            if (role == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "El rol no existe" });
            }
            var usuarioIden = await userManager.FindByNameAsync(userName);
            if (usuarioIden == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "El usuario no existe" });
            }
            var result = await userManager.AddToRoleAsync(usuarioIden, rolName);
            if (result.Succeeded)
            {
                return new IdentityRole
                {
                };
            }
            throw new Exception("No se logro agregar el rol al usuario");
        }
        /// <summary>
        /// Metodo que sirve para Eliminar un rol a un usuario
        /// </summary>
        public async Task<IdentityRole> UsuarioRolEliminar(string userName, string rolName)
        {
            var role = await rolManager.FindByNameAsync(rolName);
            if (role == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el Rol" });
            }
            var usuarioIden = await userManager.FindByNameAsync(userName);
            if (usuarioIden == null)
            {
                throw new ExceptionBase(HttpStatusCode.NotFound, new { Mensaje = "No se encontro el Usuario" });
            }
            var result = await userManager.RemoveFromRoleAsync(usuarioIden, rolName);
            if (result.Succeeded)
            {
                return new IdentityRole
                {
                };
            }
            throw new Exception("No se logro eliminar el rol al usuario");
        }
    }
}
