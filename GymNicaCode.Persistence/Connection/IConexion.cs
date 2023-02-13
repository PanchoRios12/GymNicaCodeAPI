using GymNicaCode.Domain;
using GymNicaCode.Persistence.FluentApi;
using Marques.EFCore.SnakeCase;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymNicaCode.Persistence.Connection
{
    public partial class IConexion : IdentityDbContext<Usuario>
    {
        public IConexion(DbContextOptions options) : base(options)
        {
        }
        //Lista de tablas
        public virtual DbSet<Traduccion> Traduccion { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }


        /// <summary>
        /// Sobreescritura del model creating
        /// </summary>
        /// <param name="modelBuilder">Modelo de configuracion</param>
        /// Johnny Arcia
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new FluentApiBase().Map(ref modelBuilder);
            modelBuilder.RemovePluralizingTableNameConvention();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }

    /// <summary>
    /// Configuracion del model builder
    /// </summary>
    /// Johnny Arcia
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Clase para quitar la pluralizacionde las tablas y usar un formato snake-case en los nombres de tablas y campos
        /// </summary>
        /// <param name="modelBuilder">referencia del modelo de configuracion</param>
        /// Johnny Arcia
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                //Nombres de tablas formato snake case
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                //Se recorren las propiedades del modelo y se deja en formato snake case
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }

                //Se recorren las llaves primarias del modelo y se deja en formato snake case
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                //Se recorren las llaves foraneas del modelo y se dejan en formato snake case
                foreach (var key in entity.GetForeignKeys())
                {
                    key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
                }

                //Se recorren los indices del modelo y se dejan en formato snake case
                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }
    }
}
