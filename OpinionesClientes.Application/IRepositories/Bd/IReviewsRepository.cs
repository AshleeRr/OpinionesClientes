using OpinionesCLientes.Domain.Entities.Db;

namespace OpinionesClientes.Application.IRepositories.Bd
{
    public interface IReviewsRepository
    {
        Task<IEnumerable<Reviews>> ExtractReviewsDataAsync();
    }
}
