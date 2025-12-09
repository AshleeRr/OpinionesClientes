
using CsvHelper.Configuration.Attributes;

namespace OpinionesCLientes.Domain.Entities.Csv
{
    public class Surveys
    {
        public int IdOpinion { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public DateOnly Fecha { get; set; }
        public required string Comentario { get; set; }
        public required string Clasificacion { get; set; }
        public int PuntajeSatisfaccion { get; set; } 
        public required string Fuente { get; set; } 
    }
}
