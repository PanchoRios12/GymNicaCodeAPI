using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Query
{
    public interface IEmpleadoQuery
    {
        Task<List<EmpleadoDto>> listaEmpleado();
        Task<EmpleadoDto> empleadoPorId(int idEmpleado);
        Task<PaginationRequestBase<EmpleadoDto>> listaEmpleadoPaginado(PaginationDto pagination);

    }
}
