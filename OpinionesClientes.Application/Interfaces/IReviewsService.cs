using OpinionesClientes.Application.Results;

namespace OpinionesClientes.Application.Interfaces
{
    public interface IReviewsService
    {
        Task<ServiceResult> ProcessReviewsDataAsync();
    }
}
