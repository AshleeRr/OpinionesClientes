
namespace OpinionesCLientes.Domain.Entities.Dwh.Dimensions
{
    public class DimFuente_Datos
    {
        public int FuenteKey { get; set; }
        public string? FuenteId { get; set; }
        public string? NombreFuente { get; set; }
        public string? TipoFuente { get; set; }
        public DateTime FechaDeCarga { get; set; }
    }
}
