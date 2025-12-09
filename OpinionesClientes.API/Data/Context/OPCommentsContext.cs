using Microsoft.EntityFrameworkCore;
using OpinionesClientes.Api.Data.Entities;

namespace OpinionesClientes.API.Data.Context
{
    public class OPCommentsContext : DbContext
    {
        public OPCommentsContext(DbContextOptions<OPCommentsContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Comments> Social_Comments { get; set; }
        #endregion
    }
}
