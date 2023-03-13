using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNicaCode.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymNicaCode.Persistence.FluentApi
{
    /// <summary>
    /// Configuracion del modelo cliente
    /// </summary>
    /// <param name="builder">Configuracion de la entidad cliente</param>
    /// Francisco Rios
    public class ClienteConfiguartion : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CodigoCliente).IsRequired();
            builder.Property(e => e.NombresCliente).IsRequired();
            builder.Property(e => e.ApellidosCliente).IsRequired();
            builder.Property(e => e.Cedula).IsRequired();
            builder.Property(e => e.NoCelular).IsRequired();
            builder.Property(e => e.Correo).IsRequired();
            builder.Property(e => e.Estado).HasColumnType("bit");
        }
    }
}
