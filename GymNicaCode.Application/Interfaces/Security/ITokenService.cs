﻿using GymNicaCode.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Interfaces.Security
{
    public interface ITokenService
    {
        /// <summary>
        /// Implementacion encargado de crear nuevos tokens
        /// </summary>
        /// <param name="usuario">Entidad Usuario</param>
        /// <param name="roles">Roles del usuario</param>
        /// <returns>Nuevo Token</returns>
        string CreateToken(Usuario usuario, IList<string> roles);
    }
}
