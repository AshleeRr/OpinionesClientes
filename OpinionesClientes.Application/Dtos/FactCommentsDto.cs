
namespace OpinionesClientes.Application.Dtos
{
    public class FactCommentsDto
    {
        public int ComentarioKey { get; set; }
        public int ComentarioId { get; set; }
        public string? Comentario { get; set; }
        public DateOnly FechaRealizacion { get; set; }
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public string? Clasificacion { get; set; }
        public int? Rating { get; set; }
        public int IdFuente { get; set; }
    }
}
