using System.ComponentModel.DataAnnotations;

namespace MVCENTITYCRUD.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
