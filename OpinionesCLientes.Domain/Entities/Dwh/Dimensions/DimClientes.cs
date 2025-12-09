
using System.ComponentModel.DataAnnotations;

namespace OpinionesCLientes.Domain.Entities.Dwh.Dimensions
{
    public class DimClientes
    {
        [Key]
        public int ClienteKey { get; set; }
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
    }
}
