using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Query
{
    public interface IRolQuery
    {
        Task<List<string>> ObtenerRolesPorUsuario(string userName);
        Task<List<IdentityRole>> ListaRoles();
    }
}
