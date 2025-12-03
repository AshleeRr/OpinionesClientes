
using Microsoft.EntityFrameworkCore;
using OpinionesCLientes.Domain.Entities.Dwh.Dimensions;
using OpinionesCLientes.Domain.Entities.Dwh.Facts;

namespace OpinionesClientes.Persistence.Repositories.Dwh.Context
{
    public class DwhContext : DbContext
    {
        public DwhContext(DbContextOptions<DwhContext> options) : base(options)
        {
        }
        #region Clases DbSet Dimensions
        public DbSet<DimClientes> Clientes { get; set; }
        public DbSet<DimProductos> Productos { get; set; }
        public DbSet<DimFuente_Datos> Fuente_Datos { get; set; }
        #endregion

        #region Clases DbSet Facts
        public DbSet<FactComentarios> Comentarios { get; set; }
        #endregion
    }
}
