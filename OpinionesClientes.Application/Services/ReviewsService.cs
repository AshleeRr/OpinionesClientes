
using OpinionesClientes.Application.Interfaces;
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesClientes.Application.IRepositories.Bd;
using OpinionesClientes.Application.IRepositories.Csv;
using OpinionesClientes.Application.Results;

namespace OpinionesClientes.Application.Services
{
    public class ReviewsService : IReviewsService //A procesar la data en el dwh
                                                  //Pero primero pasar los datos
    {
        private readonly IReviewsRepository _revRepository;
        private readonly ICommentsApiRepository _apiRepository;
        private readonly ICsvSurveysFileReaderRepository _csvSurveyRepository;
        public ReviewsService(IReviewsRepository revRepository, 
                              ICommentsApiRepository apiRepository, 
                              ICsvSurveysFileReaderRepository csvSurveyRepository) 
        {
            _revRepository = revRepository;
            _apiRepository = apiRepository;
            _csvSurveyRepository = csvSurveyRepository;
        }
        public Task<ServiceResult> ProcessReviewsDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
