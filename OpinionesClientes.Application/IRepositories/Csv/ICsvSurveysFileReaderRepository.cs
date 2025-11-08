using OpinionesCLientes.Domain.Entities.Csv;
using OpinionesCLientes.Domain.IRepositories;

namespace OpinionesClientes.Application.IRepositories.Csv
{
    public interface ICsvSurveysFileReaderRepository : IFileReaderRepository<Surveys>{}
}
