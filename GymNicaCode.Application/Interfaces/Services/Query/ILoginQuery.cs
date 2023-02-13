using GymNicaCode.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Query
{
    public interface ILoginQuery
    {
        Task<List<string>> ObtenerRolesPorUsuario(string userName);
        Task<UsuarioDto> UsuarioActual();
    }
}
