using System.ComponentModel.DataAnnotations;

namespace MVCENTITYCRUD.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public List<Empleado> Empleados { get; set; }
    }
}
