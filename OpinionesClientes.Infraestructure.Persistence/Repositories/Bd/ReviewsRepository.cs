using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpinionesClientes.Application.IRepositories.Bd;
using OpinionesClientes.Persistence.Repositories.Bd.Context;
using OpinionesCLientes.Domain.Entities.Db;
namespace OpinionesClientes.Persistence.Repositories.Bd
{
    public class ReviewsRepository : IReviewsRepository
    {
        private readonly ILogger _logger;
        private readonly OPReviewsContext _context;

        public ReviewsRepository(OPReviewsContext context,
                                ILogger<ReviewsRepository> logger)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IEnumerable<Reviews>> ExtractReviewsDataAsync()
        {
            try
            {
                return await _context.Web_Reviews.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error extracting Reviews data from database: {ex.Message}");
                return Enumerable.Empty<Reviews>();
            }
        }
    }
}
