
using System.ComponentModel.DataAnnotations;

namespace OpinionesCLientes.Domain.Entities.Db
{
    public class Reviews
    {
        [Key]
        public string? IdReview { get; set; }
        public string? IdCliente { get; set; }
        public string? IdProducto { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Comentario { get; set; }
        public int? Rating { get; set; } 
    }
}
