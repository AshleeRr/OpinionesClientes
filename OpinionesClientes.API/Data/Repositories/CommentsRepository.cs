using Microsoft.EntityFrameworkCore;
using OpinionesClientes.Api.Data.Entities;
using OpinionesClientes.API.Data.Context;
using OpinionesClientes.API.Data.Interfaces;

namespace OpinionesClientes.API.Data.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly OPCommentsContext _context;

        public CommentsRepository(OPCommentsContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comments>> GetAllCommentsAsync()
        {
            return await _context.Comments.ToArrayAsync();
        }
    }
}
