
using CsvHelper.Configuration.Attributes;

namespace OpinionesCLientes.Domain.Entities.Fuente
{
    public class ProductosCsv
    {
        public int IdProducto { get; set; }
        public string? Nombre { get; set; }
        [Name("Categoría")] 
        public string Categoria { get; set; }
    }
}
