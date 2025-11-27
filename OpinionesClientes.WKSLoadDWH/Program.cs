using Microsoft.EntityFrameworkCore;
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesClientes.Application.IRepositories.Csv;
using OpinionesClientes.Persistence.Repositories.Api;
using OpinionesClientes.Persistence.Repositories.Bd.Context;
using OpinionesClientes.Persistence.Repositories.Csv;

namespace OpinionesClientes.WKSLoadDWH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();
            builder.Services.AddScoped<ICsvSurveysFileReaderRepository, CsvSurveysFileReaderRepository>();
            builder.Services.AddScoped<ICommentsApiRepository, CommentsApiRepository>();
            builder.Services.AddDbContext<OPReviewsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));

            //builder.Services.AddHttpClient("CommentsApiClient");
            builder.Services.AddHttpClient("CommentsApiClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiConfig:BaseUrl"]!);
            });

            var host = builder.Build();
            host.Run();
        }
    }
}