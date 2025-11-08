using OpinionesCLientes.Domain.Entities.Api;

namespace OpinionesClientes.Application.IRepositories.Api
{
    public interface ICommentsApiRepository
    {
        Task<IEnumerable<Comments>> GetCommentsAsync();
    }
}
