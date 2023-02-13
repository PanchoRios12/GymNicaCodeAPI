using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Exceptions
{
    public sealed class ValidationException : ApplicationException
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base("Fallo de validación", "Ocurrio uno o mas errores")
            => ErrorsDictionary = errorsDictionary;

        /// <summary>
        /// Diccionario para los errores de middleware
        /// </summary>
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
