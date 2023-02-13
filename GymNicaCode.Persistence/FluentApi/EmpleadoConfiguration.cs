using GymNicaCode.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Persistence.FluentApi
{
    /// <summary>
    /// Configuracion del modelo empleado
    /// </summary>
    /// <param name="builder">Configuracion de la entidad empleado</param>
    /// Francisco Rios
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
           builder.HasKey(e => e.Id);
           builder.Property(e => e.CodigoEmpleado).IsRequired();
           builder.Property(e => e.FechaIngreso).IsRequired();
           builder.Property(e => e.Nombres).IsRequired();
           builder.Property(e => e.Apellidos).IsRequired();
           builder.Property(e => e.Cedula).IsRequired();
           builder.Property(e => e.Celular).IsRequired();
           builder.Property(e => e.Direccion).IsRequired();
           builder.Property(e => e.Estado).HasColumnType("bit");
        }
    }
}
