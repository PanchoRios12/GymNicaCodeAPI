using AutoMapper;
using GymNicaCode.Application.Dtos;
using GymNicaCode.Application.Dtos.Base;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Domain;
using GymNicaCode.Persistence.Base;
using GymNicaCode.Persistence.Connection;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GymNicaCode.Services.Services
{
    public class ClienteService : IClienteService
    {

        private IMapper _mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public ClienteService() 
        { 
        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public ClienteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega un nuevo cliente
        /// </summary>
        /// <param name="Cliente">cliente</param>
        /// <returns>cliente <returns>
        /// Francisco Rios
        public async Task<ClienteDto> crearCliente(ClienteDto cliente)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new BaseSpecification<Cliente>();
                var totalData = await _unitOfWork.Repository<Cliente>().CountAsync(query);
                totalData = totalData + 1;
                if (Convert.ToString(totalData).Length == 1)
                {
                    cliente.CodigoCliente = "000" + totalData.ToString();
                }
                else if (Convert.ToString(totalData).Length == 2)
                {
                    cliente.CodigoCliente = "00" + totalData.ToString();
                }
                else
                {
                    cliente.CodigoCliente = "0" + totalData.ToString();
                }
                var repository = _unitOfWork.Repository<Cliente>();
                Cliente newCliente= new Cliente();
                _mapper.Map(cliente, newCliente);
                repository.AddEntity(newCliente);
                await _unitOfWork.Complete();
                return cliente;

            }
        }
        /// <summary>
        /// Actualiza un cliente por Id
        /// </summary>
        /// <param name="Id">Id cliente/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<ClienteDto> actualizarCliente(ClienteDto cliente)
        {
            using (var unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = unitOfWork.Repository<Cliente>();
                Cliente newCliente = new Cliente();
                _mapper.Map(cliente, newCliente);   
                repository.UpdateEntity(newCliente);
                await unitOfWork.Complete();
                return cliente;
            }
        }
        /// <summary>
        /// Obtiene todos los cliente
        /// </summary>
        /// <returns>Obtiene todos los cliente</returns>
        /// Francisco Rios
        public async Task<List<ClienteDto>> listaCliente()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var listaCliente = await _unitOfWork.Repository<Cliente>().GetAllAsync();
                return _mapper.Map<List<Cliente>, List<ClienteDto>>(listaCliente.ToList());
            }
        }
        /// <summary>
        /// Obtiene una persona por Id
        /// </summary>
        /// <param name="IdPersona">IdPersona</param>
        /// <returns>Retorna una persona</returns>
        /// Francisco Rios
        public async Task<ClienteDto> ClientePorId(int idCliente)
        {
            using (var _UnitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new BaseSpecification<Cliente>(x => x.Id == idCliente);
                var cliente = await _UnitOfWork.Repository<Cliente>().GetByIdWithSpec(query);
                return _mapper.Map<Cliente, ClienteDto>(cliente);
            }
        }

        public async Task<PaginationRequestBase<ClienteDto>> listaClientePaginado(PaginationDto pagination)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new BaseSpecification<Cliente>(x => (pagination.generalSearch == null || x.NombresCliente.Contains(pagination.generalSearch)) && (pagination.Estado == null || x.Estado == pagination.Estado));
                var totalData = await _unitOfWork.Repository<Cliente>().CountAsync(query);

                if (pagination.sort == SortEnum.desc) query.AddOrderByDescending(x => x.Id);
                else query.AddOrderBy(x => x.Id);

                query.ApplyPaging(pagination.perpage * (pagination.page - 1), pagination.perpage);

                var listCliente = await _unitOfWork.Repository<Cliente>().GetAllWithSpec(query);
                var request = new PaginationRequestBase<ClienteDto>
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
                    data = _mapper.Map<List<Cliente>, List<ClienteDto>>(listCliente.ToList())
                };
                return request;
            }
        }
    }
}
