using MVC_CRUD_Proyecto_8CodeFirst.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Proyecto_8CodeFirst.Model.DAL
{
    public class EstudianteContext : DbContext

    {
        public EstudianteContext()
             : base("EstudianteContext")
        {
        }

        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

    }

}
