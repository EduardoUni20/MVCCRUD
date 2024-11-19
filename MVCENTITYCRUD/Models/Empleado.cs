using System.ComponentModel.DataAnnotations;

namespace MVCENTITYCRUD.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        public required string NombreCompleto { get; set; }
        public required string Correo { get; set; }
        public DateOnly FechaContrato { get; set; }
        public bool Activo { get; set; }


        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
