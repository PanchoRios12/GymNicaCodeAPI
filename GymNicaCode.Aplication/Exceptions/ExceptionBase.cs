using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GymNicaCode.Application.Exceptions
{
    public class ExceptionBase : Exception
    {
        /// <summary>
        /// Codigo de estado http
        /// </summary>
        public HttpStatusCode codigo { get; }
        /// <summary>
        /// Objeto anonimo de errores
        /// </summary>
        public object errores { get; }
        /// <summary>
        /// Constructor de encapsulamiento
        /// </summary>
        /// <param name="_codigo">Codigo estado Http</param>
        /// <param name="_errores">Objeto con los errores</param>
        /// Johnny Arcia
        public ExceptionBase(HttpStatusCode _codigo, object _errores = null)
        {
            codigo = _codigo;
            errores = _errores;
        }
    }
}
