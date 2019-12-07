using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_CRUD_Proyecto_8CodeFirst.Model.Models
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Nullable<System.DateTime> Fecha_Ingreso { get; set; }
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }

    }
}
