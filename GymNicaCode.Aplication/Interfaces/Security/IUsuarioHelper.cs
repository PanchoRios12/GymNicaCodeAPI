using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Interfaces.Security
{
    public interface IUsuarioHelper
    {
        /// <summary>
        /// Obtiene el nombre del usuario logeado
        /// </summary>
        /// <returns>Nombre del usuario</returns>
        /// Johnny Arcia
        string ObtenerUsuarioSesion();
    }
}
