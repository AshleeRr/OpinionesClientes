
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
        #region DbSet Dimensions
        public DbSet<DimClientes> DimClientes { get; set; }
        public DbSet<DimProductos> DimProductos { get; set; }
        public DbSet<DimFuente_Datos> DimFuente_Datos { get; set; }
        #endregion

        #region DbSet Facts
        public DbSet<FactComentarios> FactComentarios { get; set; }
        #endregion
    }
}