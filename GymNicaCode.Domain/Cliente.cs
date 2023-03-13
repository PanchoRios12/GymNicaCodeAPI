using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Domain
{
    public class Cliente:ClaseBase
    {
       
        public string CodigoCliente { get; set; }
        /// <summary>
        /// NombresCliente
        /// </summary>
        public string NombresCliente { get; set; }
        /// <summary>
        /// ApellidosCliente
        /// </summary>
        public string ApellidosCliente { get; set; }
        /// <summary>
        /// NoCelular
        /// </summary>
        public int? NoCelular { get; set; }
        /// <summary>
        /// Correo
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Cedula
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Foto
        /// </summary>
        public byte[] FotoCliente { get; set; }
        /// <summary>
        /// CalveDeAcceso
        /// </summary>
        public string ClaveDeAcceso { get; set; }
       
    }
}
