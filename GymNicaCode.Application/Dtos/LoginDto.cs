using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Recordar { get; set; }
    }
}
