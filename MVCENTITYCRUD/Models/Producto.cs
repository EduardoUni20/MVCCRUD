using System.ComponentModel.DataAnnotations;

namespace MVCENTITYCRUD.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Precio { get; set; }
        public string Ingredientes { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
