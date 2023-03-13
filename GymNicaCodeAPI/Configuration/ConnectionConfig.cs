using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using GymNicaCode.Persistence.Connection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace GymNicaCodeAPI.Configuration
{
    public static class ConnectionConfig
    {
        public static void Config(IConfiguration Configuration, IServiceCollection services)
        {
            //Se busca el tipo de base de datos configurada
            var db = Configuration.GetValue<string>("Database");
            //Se obtiene la ruta del contexto por medio de su NameSpace --gymnicacode.Persistence.Mysql
            string assemblyName = typeof(ConexionMysql).Namespace;
            string mySqlConnectionStr = Configuration.GetConnectionString("mysqlConnection");
            var serverVersion = ServerVersion.AutoDetect(mySqlConnectionStr);

            //Se inicializa las conexiones globales
            SingletonConexiones.optionsConexion = new DbContextOptionsBuilder<IConexion>().UseMySql(mySqlConnectionStr, serverVersion);
            SingletonConexiones.ConnectionString = mySqlConnectionStr;
            services.AddDbContextPool<IConexion>(options => options.UseMySql(mySqlConnectionStr,serverVersion,
                //Se configura la ruta de migraciones por defecto en este contexto
                optionsBuilder => {
                    optionsBuilder.MigrationsAssembly(assemblyName);
                }));

        }
    }
}
