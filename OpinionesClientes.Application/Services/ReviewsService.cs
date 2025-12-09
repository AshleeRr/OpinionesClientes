using OpinionesClientes.Application.Dtos;
using OpinionesClientes.Application.Interfaces;
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesClientes.Application.IRepositories.Bd;
using OpinionesClientes.Application.IRepositories.Csv;
using OpinionesClientes.Application.IRepositories.Dwh;
using OpinionesClientes.Application.Results;

namespace OpinionesClientes.Application.Services
{
    public class ReviewsService : IReviewsService //A procesar la data en el dwh
                                                  //Pero primero pasar los datos
    {

        private readonly IReviewsRepository _revRepository;
        private readonly ICommentsApiRepository _apiRepository;
        private readonly ICsvSurveysFileReaderRepository _csvSurveyRepository;
        private readonly IDwhRepository _dwhRepo;       
        public ReviewsService(IReviewsRepository revRepository, ICommentsApiRepository apiRepository,
                              IDwhRepository dwhRepo, ICsvSurveysFileReaderRepository csvSurveyRepository) 
        {
            _revRepository = revRepository;
            _apiRepository = apiRepository;
            _csvSurveyRepository = csvSurveyRepository;
            _dwhRepo = dwhRepo;
        }
        public async Task<ServiceResult> ProcessReviewsDataAsync()
        {
            var CsvSurveys = await _csvSurveyRepository.ReadFileAsync();
            var DbReviews = await _revRepository.ExtractReviewsDataAsync();
            var apiComments = await _apiRepository.GetCommentsAsync();

            var Dto = new List<FactCommentsDto>();

            int fuenteCsv = await _dwhRepo.GetOrCreateFuenteKeyAsync("FuenteInterna");
            int fuenteBd = await _dwhRepo.GetOrCreateFuenteKeyAsync("bd");

            foreach(var r in DbReviews)
            {
                Dto.Add(new FactCommentsDto
                {
                    ComentarioId = NormalizeIds(r.IdReview),
                    Comentario = r.Comentario,
                    FechaRealizacion = r.Fecha,
                    IdCliente = NormalizeIds(r.IdCliente),
                    IdProducto = NormalizeIds(r.IdProducto),
                    Rating = r.Rating,
                    IdFuente = fuenteBd 
                });
            }
            foreach (var s in CsvSurveys)
            {

                Dto.Add(new FactCommentsDto
                {
                    ComentarioId = s.IdOpinion,
                    Comentario = s.Comentario,
                    FechaRealizacion = s.Fecha,
                    IdCliente = s.IdCliente,
                    IdProducto = s.IdProducto,
                    Clasificacion = s.Clasificacion,
                    Rating = s.PuntajeSatisfaccion,
                    IdFuente = fuenteCsv,
            
                });
            }
      
            foreach ( var c in apiComments)
            {
                int fuenteApi = await _dwhRepo.GetOrCreateFuenteKeyAsync(c.Fuente);

                Dto.Add(new FactCommentsDto
                {
                    ComentarioId = NormalizeIds(c.IdComment),
                    Comentario = c.Comentario,
                    FechaRealizacion = c.Fecha,
                    IdCliente = NormalizeIds(c.IdCliente),
                    IdProducto = NormalizeIds(c.IdProducto),
                    IdFuente = fuenteApi
                });
            }
            await _dwhRepo.LoadFactsDataAsync(Dto);

            return ServiceResult.Success("Extracción completada");
        }

        private static int NormalizeIds(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return 0;

            var digits = new string(id.Where(char.IsDigit).ToArray());

            if (int.TryParse(digits, out int result))
                return result;

            return 0;
        }
    }
}
