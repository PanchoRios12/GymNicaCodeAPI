using Microsoft.Extensions.Configuration;
using GymNicaCode.Application.Interfaces.Services;
using GymNicaCode.Application.Interfaces.Services.Command;
using GymNicaCode.Application.Interfaces.Services.Query;
using GymNicaCode.Services.Command;
using GymNicaCode.Services.Query;
using GymNicaCode.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GymNicaCodeAPI.Configuration
{
    public static class ServicesConfig
    {
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Services
            services.AddScoped<ITraduccionService, TraduccionService>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IClienteService, ClienteService>();
            //Querys
            services.AddScoped<ITraductorQuery, TraduccionQuery>();
            services.AddScoped<ILoginQuery, LoginQuery>();
            services.AddScoped<IRolQuery, RolQuery>();
            services.AddScoped<IEmpleadoQuery, EmpleadoQuery>();
            services.AddScoped<IClienteQuery, ClienteQuery>();
            //Commands
            services.AddScoped<ITraductorCommand, TraduccionCommand>();
            services.AddScoped<ILoginCommand, LoginCommand>();
            services.AddScoped<IRolCommand, RolCommand>();
            services.AddScoped<IEmpleadoCommand, EmpleadoCommand>();
            services.AddScoped<IClienteCommand, ClienteCommand>();
        }
    }
}
