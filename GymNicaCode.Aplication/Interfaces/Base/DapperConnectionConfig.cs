using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Interfaces.Base
{
    public class DapperConnectionConfig
    {
        /// <summary>
        /// Conexion MySql
        /// </summary>
        public string mysqlConnection { get; set; }
        /// <summary>
        /// Conexion SqlServer
        /// </summary>
        public string sqlServerConnection { get; set; }
    }
}
