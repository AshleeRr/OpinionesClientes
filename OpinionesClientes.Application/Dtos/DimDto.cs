
using OpinionesCLientes.Domain.Entities.Dwh.Dimensions;

namespace OpinionesClientes.Application.Dtos
{
    public class DimDto
    {
        public List<DimClientes> Clientes { get; set; }
        public List<DimProductos> Productos { get; set; }
        public List<DimFuente_Datos> FuentesDatos { get; set; }
    }
}
