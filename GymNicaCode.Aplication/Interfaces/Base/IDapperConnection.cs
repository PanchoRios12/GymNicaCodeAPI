using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GymNicaCode.Application.Interfaces.Base
{
    public interface IDapperConnection
    {
        /// <summary>
        /// Implementacion cierre de conexion
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// Implementacion obtener conexion
        /// </summary>
        /// <returns>Conexion Dapper</returns>
        IDbConnection GetConnection();
    }
}
