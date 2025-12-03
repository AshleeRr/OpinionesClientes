using OpinionesClientes.Application.Dtos;

namespace OpinionesClientes.Application.IRepositories.Dwh
{
    public interface IDwhRepository
    {
        Task LoadDimsDataAsync(DimDto dimDtos);
    }
}
