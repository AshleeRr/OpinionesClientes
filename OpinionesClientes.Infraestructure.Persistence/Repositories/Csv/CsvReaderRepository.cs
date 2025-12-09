
using CsvHelper;
using CsvHelper.Configuration;
using OpinionesCLientes.Domain.IRepositories;
using System.Globalization;

namespace OpinionesClientes.Persistence.Repositories.Csv
{
    public class CsvReaderRepository<T> : ICsvReaderRepository<T> where T : class
    {
        public List<T> ReadCsv(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, config);

            return [.. csv.GetRecords<T>()];
        }
    }
}
