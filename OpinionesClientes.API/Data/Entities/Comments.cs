using System.ComponentModel.DataAnnotations;

namespace OpinionesClientes.Api.Data.Entities
{
    public class Comments
    {
        [Key]
        public string? IdComment { get; set; }
        public string? IdCliente { get; set; }
        public string? IdProducto { get; set; }
        public required string Comentario { get; set; }
        public required string Fuente { get; set; }
        public DateOnly Fecha { get; set; }
    }
}
