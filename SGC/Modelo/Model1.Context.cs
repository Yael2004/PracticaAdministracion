﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGC.Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SistemaGeneracionConstanciasEntities : DbContext
    {
        public SistemaGeneracionConstanciasEntities()
            : base("name=SistemaGeneracionConstanciasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<DocenteExperienciaEducativa> DocenteExperienciaEducativa { get; set; }
        public virtual DbSet<ExperienciaEducativa> ExperienciaEducativa { get; set; }
        public virtual DbSet<PersonalAdministrativo> PersonalAdministrativo { get; set; }
        public virtual DbSet<ProgramaEducativo> ProgramaEducativo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}