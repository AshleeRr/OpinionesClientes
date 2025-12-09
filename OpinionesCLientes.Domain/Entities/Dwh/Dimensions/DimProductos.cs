
using System.ComponentModel.DataAnnotations;

namespace OpinionesCLientes.Domain.Entities.Dwh.Dimensions
{
    public class DimProductos
    {
        [Key]
        public int ProductKey { get; set; }
        public int ProductId { get; set; }
        public string? Nombre { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
