using GymNicaCode.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Interfaces.Security
{
    public interface IJwtGenerador
    {
        /// <summary>
        /// Metodo encargado de crear token del usuario
        /// </summary>
        /// <param name="usuario">Objeto Usuario</param>
        /// <param name="roles">Lista de nombres de roles para el usuario</param>
        /// <returns>Token de conexion</returns>
        /// <remarks>Johnny Arcia</remarks>
        string CrearToken(Usuario usuario, List<string> roles);
    }
}
