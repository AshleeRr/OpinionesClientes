
namespace OpinionesCLientes.Domain.IRepositories
{
    public interface ICsvReaderRepository<T> where T : class
    {
        List<T> ReadCsv(string path);
    }
}
