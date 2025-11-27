
using Microsoft.EntityFrameworkCore;
using OpinionesCLientes.Domain.Entities.Db;

namespace OpinionesClientes.Persistence.Repositories.Bd.Context
{
    public class OPReviewsContext : DbContext
    {
        public OPReviewsContext(DbContextOptions<OPReviewsContext> options): base(options)
        {

        }

        #region Clases DbSet
        public DbSet<Reviews> Reviews { get; set; }
        #endregion
    }
}
