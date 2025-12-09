using OpinionesClientes.Application.Dtos;

namespace OpinionesClientes.Application.IRepositories.Dwh
{
    public interface IDwhRepository
    {
        Task LoadDimsDataAsync(DimDto dimDtos);
        Task LoadFactsDataAsync(List<FactCommentsDto> factDtos);
        Task<int> GetOrCreateFuenteKeyAsync(string tipoFuente);
        Task CleanFactsAsync();
        Task CleanDimensionsAsync();

    }
}
