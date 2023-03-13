using AutoMapper;
using GymNicaCode.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Application.Dtos
{
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<Traduccion, TraduccionDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
        }
    }
}
