using OpinionesClientes.Api.Data.Entities;

namespace OpinionesClientes.API.Data.Interfaces
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comments>> GetAllCommentsAsync();
    }
}
