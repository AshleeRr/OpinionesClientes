using OpinionesCLientes.Domain.Entities.Fuente;

namespace OpinionesClientes.Application.Dtos
{
    public class DimDto
    {
        public List<ClientesCsv> Clientes { get; set; }
        public List<ProductosCsv> Productos { get; set; }
        public List<Fuente_DatosCsv> FuentesDatos { get; set; }
    }
}
