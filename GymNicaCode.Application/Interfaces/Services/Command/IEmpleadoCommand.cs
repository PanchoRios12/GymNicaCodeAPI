﻿using GymNicaCode.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Application.Interfaces.Services.Command
{
    public interface IEmpleadoCommand
    {
        Task<EmpleadoDto> crearEmpleado(EmpleadoDto empleado);
        Task<EmpleadoDto> actualizarEmpleado(EmpleadoDto empleado);
    }
}
