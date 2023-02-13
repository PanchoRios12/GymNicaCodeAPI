using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Domain
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }
        public bool Activo { get; set; }
    }
}
