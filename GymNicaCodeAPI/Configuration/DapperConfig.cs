using GymNicaCode.Application.Interfaces;
using GymNicaCode.Application.Interfaces.Base;
using GymNicaCode.Persistence.Connection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace GymNicaCodeAPI.Configuration
{
    public static class DapperConfig
    {
        /// <summary>
        /// Metodos de configuracion
        /// </summary>
        /// <param name="Configuration">Configuracion del entorno</param>
        /// <param name="services">Servicios de registro Startup</param>
        /// Johnny Arcia
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Agregar el Dapper
            services.Configure<DapperConnectionConfig>(Configuration.GetSection("ConnectionStrings"));
            //Configuramos las conexiones de dapper
            //SingletonConexiones.optionsDapperconexion.Value.mysqlConnection = Configuration.GetConnectionString("mysqlConnection");
            //SingletonConexiones.optionsDapperconexion.Value.sqlServerConnection = Configuration.GetConnectionString("sqlServerConnection");
            services.AddTransient<IDapperConnection, DapperConnection>();
        }
    }
}
