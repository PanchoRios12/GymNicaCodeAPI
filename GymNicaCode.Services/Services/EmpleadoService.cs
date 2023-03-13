using AutoMapper;
using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using GymNicaCode.Application.Interfaces.Base;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Domain;
using GymNicaCode.Persistence.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymNicaCode.Services.Services
{
    public class EmpleadoService: IEmpleadoService
    {
        private IMapper _mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public EmpleadoService()
        {
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public EmpleadoService(IMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// Agrega un nuevo empleado
        /// </summary>
        /// <param name="Empleado">Empleado</param>
        /// <returns>Empleado <returns>
        /// Francisco Rios
        public async Task<EmpleadoDto> crearEmpleado(EmpleadoDto empleado)
        {
            using (var _unitOfWork= new Contextos().GetUnitOfWork())
            {
                var query = new Persistence.Base.BaseSpecification<Empleado>();
                var totalData = await _unitOfWork.Repository<Empleado>().CountAsync(query);
                totalData =totalData+ 1;
                if ( Convert.ToString(totalData).Length==1)
                {
                    empleado.CodigoEmpleado = "000" + totalData.ToString();
                }
                else if ( Convert.ToString(totalData).Length==2)
                {
                    empleado.CodigoEmpleado = "00" + totalData.ToString();
                }
                else
                {
                    empleado.CodigoEmpleado = "0" + totalData.ToString();
                }

                empleado.FechaIngreso = Convert.ToDateTime(empleado.FechaIngresoString);
                var reporitory = _unitOfWork.Repository<Empleado>();
                Empleado newEmpleado = new Empleado();
                _mapper.Map(empleado, newEmpleado);
                reporitory.AddEntity(newEmpleado);
                await _unitOfWork.Complete();
                return empleado;
            }
        }
        /// <summary>
        /// Actualiza un empleado por Id
        /// </summary>
        /// <param name="Id">Id Empleado/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<EmpleadoDto> actualizarEmpleado(EmpleadoDto empleado)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                if ( empleado.FechaIngresoString != null )
                {
                    empleado.FechaIngreso = DateTime.ParseExact(empleado.FechaIngresoString, "dd/MM/yyyy", null);
                }
                var repository = _unitOfWork.Repository<Empleado>();
                Empleado newEmpleado = new Empleado();
                _mapper.Map(empleado, newEmpleado);
                repository.UpdateEntity(newEmpleado);
                await _unitOfWork.Complete();
                return empleado;
            }
           
        }
        /// <summary>
        /// Obtiene todos los empleado
        /// </summary>
        /// <returns>Obtiene todos los empleado</returns>
        /// Francisco Rios
        public async Task<List<EmpleadoDto>> listaEmpleado()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var listEmpleado =await _unitOfWork.Repository<Empleado>().GetAllAsync();
                return _mapper.Map<List<Empleado>, List<EmpleadoDto>>(listEmpleado.ToList());
            }
        }
        
        public async Task<EmpleadoDto> empleadoPorId(int idEmpleado)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Persistence.Base.BaseSpecification<Empleado>(x => x.Id == idEmpleado);
                var empleado = await _UnitOfWork.Repository<Empleado>().GetByIdWithSpec(query);
                return _mapper.Map<Empleado, EmpleadoDto>(empleado);
            }
        }

        public async Task<PaginationRequestBase<EmpleadoDto>> listaEmpleadoPaginado(PaginationDto pagination)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Persistence.Base.BaseSpecification<Empleado>(x => (pagination.generalSearch == null || x.Nombres.Contains(pagination.generalSearch)) && (pagination.Estado == null || x.Estado == pagination.Estado));
                var totalData = await _unitOfWork.Repository<Empleado>().CountAsync(query);

                if (pagination.sort == SortEnum.desc) query.AddOrderByDescending(x => x.Id);
                else query.AddOrderBy(x => x.Id);

                query.ApplyPaging(pagination.perpage * (pagination.page - 1), pagination.perpage);

                var listTipoPersona = await _unitOfWork.Repository<Empleado>().GetAllWithSpec(query);
                var request = new PaginationRequestBase<EmpleadoDto>
                {
                    meta = new PaginationMetadataBase
                    {
                        page = pagination.page,
                        field = pagination.field,
                        pages = (totalData + pagination.perpage - 1) / pagination.perpage,
                        perpage = pagination.perpage,
                        sort = pagination.sort,
                        total = totalData
                    },
                    data = _mapper.Map<List<Empleado>, List<EmpleadoDto>>(listTipoPersona.ToList())
                };
                return request;
            }
        }
    }
}
