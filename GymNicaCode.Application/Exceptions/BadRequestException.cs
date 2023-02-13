using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Exceptions
{
    public abstract class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
    }
}
