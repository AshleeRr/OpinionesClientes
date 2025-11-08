
using Microsoft.EntityFrameworkCore;
using OpinionesCLientes.Domain.Entities.Db;

namespace OpinionesClientes.Persistence.Repositories.Bd.Context
{
    public class OPContext : DbContext
    {
        public OPContext(DbContextOptions<OPContext> options): base(options)
        {

        }

        #region Clases DbSet
        public DbSet<Reviews> Reviews { get; set; }
        #endregion
    }
}
