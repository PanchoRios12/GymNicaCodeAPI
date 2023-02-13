﻿using GymNicaCode.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Persistence.FluentApi
{
    public class TraduccionConfiguration : IEntityTypeConfiguration<Traduccion>
    {
        /// <summary>
        /// Configuracion del modelo
        /// </summary>
        /// <param name="builder">Configuracionde la entidad</param>
        /// Johnny Arcia
        public void Configure(EntityTypeBuilder<Traduccion> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).IsRequired();
            builder
                .Property(b => b.Llave)
                .IsRequired();
            builder.Property(b => b.Estado).HasColumnType("bit");
        }
    }
}
