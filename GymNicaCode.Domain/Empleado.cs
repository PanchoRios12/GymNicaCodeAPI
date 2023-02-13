using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Domain
{
    public class Empleado : ClaseBase
    {
        /// <summary>
        /// Codigo Empleado
        /// </summary>
        public string CodigoEmpleado { get; set; }
        /// <summary>
        /// Fecha Ingreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Celular
        /// </summary>
        public int Celular { get; set; }
        /// <summary>
        /// Cedula
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion  { get; set; }
 
    }
}
