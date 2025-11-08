
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesCLientes.Domain.Entities.Api;

namespace OpinionesClientes.Persistence.Repositories.Api
{
    public class CommentsApiRepository : ICommentsApiRepository
    {
        public Task<IEnumerable<Comments>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
