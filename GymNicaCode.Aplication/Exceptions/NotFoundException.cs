using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Exceptions
{
    public abstract class NotFoundException : ApplicationException
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
