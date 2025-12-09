using OpinionesClientes.Application.Dtos;
using OpinionesClientes.Application.Interfaces;
using OpinionesClientes.Application.IRepositories.Dwh;
using OpinionesCLientes.Domain.Entities.Fuente;
using OpinionesCLientes.Domain.IRepositories;

namespace OpinionesClientes.WKSLoadDWH
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var csvClientes = scope.ServiceProvider.GetRequiredService<ICsvReaderRepository<ClientesCsv>>();
                var csvProductos = scope.ServiceProvider.GetRequiredService<ICsvReaderRepository<ProductosCsv>>();
                var csvFuentes = scope.ServiceProvider.GetRequiredService<ICsvReaderRepository<Fuente_DatosCsv>>();

                var dwhRepo = scope.ServiceProvider.GetRequiredService<IDwhRepository>();
                var reviewsService = scope.ServiceProvider.GetRequiredService<IReviewsService>();
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                //EXTRAER CSVs
                var clientes = csvClientes.ReadCsv(config["CsvFilePaths:Clientes"]);
                var productos = csvProductos.ReadCsv(config["CsvFilePaths:Productos"]);
                var fuentes = csvFuentes.ReadCsv(config["CsvFilePaths:Fuentes_Datos"]);

                var dimDto = new DimDto
                {
                    Clientes = clientes,
                    Productos = productos,
                    FuentesDatos = fuentes
                };
                await dwhRepo.CleanFactsAsync();
                await dwhRepo.CleanDimensionsAsync();
               
                // CARGAR DIM TABLE
                
                await dwhRepo.LoadDimsDataAsync(dimDto);
                await reviewsService.ProcessReviewsDataAsync();

                _logger.LogInformation("Dimensiones y facts cargadas correctamente.");

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
