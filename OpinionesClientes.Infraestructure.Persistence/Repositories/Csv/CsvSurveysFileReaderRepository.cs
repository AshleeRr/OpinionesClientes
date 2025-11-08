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
            _filePath = _configuration["FilePaths:SurveysCsvFilePath"];
        }
        public async Task<IEnumerable<Surveys>> ReadFileAsync(string filePath) //leer csv
        {
            var path = filePath ?? _filePath;
            List<Surveys> surveysData = new List<Surveys>();
            
            try
            {
                _logger.LogInformation("Starting to read CSV file for Surveys data.");

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = "\t"
                };

                using var reader = new StreamReader(path);
                using var surveysCSV = new CsvReader(reader, config);
                
                var records = surveysCSV.GetRecords<Surveys>();
                surveysData.AddRange(records);
                _logger.LogInformation($"Successfully read {surveysData.Count} surveys");
            }
            catch (Exception ex)
            {
                surveysData = null;
                _logger.LogError($"Error reading CSV file: {ex.Message}");
            }
            return await Task.FromResult(surveysData!);
        }
    }
}
