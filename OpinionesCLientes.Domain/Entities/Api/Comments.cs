
namespace OpinionesCLientes.Domain.Entities.Api
{
    public class Comments
    {
        public string? IdComment { get; set; }
        public string? IdCliente { get; set; }
        public string? IdProducto { get; set; }
        public required string Fuente { get; set; } 
        public DateOnly Fecha { get; set; }
        public required string Comentario { get; set; }
    }
}
