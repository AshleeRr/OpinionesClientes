using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpinionesClientes.Application.IRepositories.Csv;
using OpinionesClientes.Application.Results;
using OpinionesCLientes.Domain.Entities.Csv;
using System.Globalization;

namespace OpinionesClientes.Persistence.Repositories.Csv
{
    public sealed class CsvSurveysFileReaderRepository : ICsvSurveysFileReaderRepository
    {
        private readonly string _filePath;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public CsvSurveysFileReaderRepository(IConfiguration configuration, ILogger<ServiceResult> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _filePath = _configuration["CsvFilePaths:Surveys"];
        }
        public async Task<IEnumerable<Surveys>> ReadFileAsync()
        {
            List<Surveys> surveysList = new();

            try
            {
                _logger.LogInformation("Leyendo Surveys CSV desde: {file}", _filePath);

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                    MissingFieldFound = null
                };

                using var reader = new StreamReader(_filePath);
                using var csv = new CsvReader(reader, config);

                var records = csv.GetRecords<Surveys>();
                surveysList.AddRange(records);

                _logger.LogInformation("Lectura completada. Registros: {count}", surveysList.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leyendo Surveys CSV");
                return Enumerable.Empty<Surveys>();
            }

            return surveysList;
        }
    }
}
