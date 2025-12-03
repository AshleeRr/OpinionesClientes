
namespace OpinionesCLientes.Domain.Entities.Dwh.Facts
{
    public class FactComentarios
    {
        public int ComentarioKey { get; set; }
        public int ComentarioId { get; set; }
        public int ProductoKey { get; set; }
        public int FuenteKey { get; set; }
        public DateTime FechaComentario { get; set; }
        public string? TextoComentario { get; set; }
        public int Calificacion { get; set; }
        public DateTime FechaDeCarga { get; set; }
    }
}
