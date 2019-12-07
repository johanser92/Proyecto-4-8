using MVC_CRUD_Proyecto_8CodeFirst.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Proyecto_8CodeFirst.Model.DAL
{
    public class CargarDatosDB : System.Data.Entity.DropCreateDatabaseIfModelChanges<EstudianteContext>
    {
        protected override void Seed(EstudianteContext context)
        {
            var Curso = new List<Curso>
            {
                new Curso{CursoID=1, Descripcion="Matematica",},
                new Curso{CursoID=2, Descripcion="Ingles",},
                new Curso{CursoID=3, Descripcion="Sociales",}

            };
            Curso.ForEach(s => context.Curso.Add(s));
            context.SaveChanges();

            var Estudiante = new List<Estudiante>
            {
                new Estudiante{Nombres="Juan Carlos",Apellidos="Reyes Jimenez", Fecha_Ingreso=DateTime.Parse("2001-09-01")},
                 new Estudiante{Nombres="Belkis",Apellidos="Jimenez", Fecha_Ingreso=DateTime.Parse("2011-09-01")},
                  new Estudiante{Nombres="Carlos",Apellidos="Reyes", Fecha_Ingreso=DateTime.Parse("2021-09-01")},
                new Estudiante{Nombres="Juan",Apellidos="Reyes Jimenez", Fecha_Ingreso=DateTime.Parse("2021-09-01")},
            };
            Estudiante.ForEach(s => context.Estudiante.Add(s));
            context.SaveChanges();

            var Inscripcion = new List<Inscripcion>
            {
                new Inscripcion{EstudianteID=1, CursoID=1},
                new Inscripcion{EstudianteID=2, CursoID=1},
                new Inscripcion{EstudianteID=3, CursoID=2},
                new Inscripcion{EstudianteID=4, CursoID=2},
            };
            Inscripcion.ForEach(s => context.Inscripcion.Add(s));
            context.SaveChanges();

        }



    }

}
