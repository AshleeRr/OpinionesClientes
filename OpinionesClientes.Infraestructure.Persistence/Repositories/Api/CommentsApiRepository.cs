
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesCLientes.Domain.Entities.Api;
using System.Net.Http.Json;

namespace OpinionesClientes.Persistence.Repositories.Api
{
    public class CommentsApiRepository : ICommentsApiRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<CommentsApiRepository> _logger;
        //private readonly IConfiguration _configuration;

        //private readonly string _baseUrl = string.Empty;

        public CommentsApiRepository(IHttpClientFactory httpClientFactory,
                                     ILogger<CommentsApiRepository> logger
                                     //,IConfiguration configuration
                                        )
        {
            _clientFactory = httpClientFactory;
            _logger = logger;
            //_configuration = configuration;
            //_baseUrl = _configuration["ApiConfig:BaseUrl"] ?? string.Empty;
        }
        public async Task<IEnumerable<Comments>> GetCommentsAsync()
        {
            List<Comments> comments = new();

            try
            {
                using var client = _clientFactory.CreateClient("CommentsApiClient");
                //client.BaseAddress = new Uri(_baseUrl);

                using var response = await client.GetAsync("api/comments/getallcomments");

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<IEnumerable<Comments>>();

                    if (apiResponse != null)
                        comments = apiResponse.ToList();
                }
                else
                {
                    _logger.LogError("Error fetching comments. Status: {StatusCode}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception when fetching comments from API");
                comments = null!;
            }

            return comments!;
        }
    }
}