using Microsoft.EntityFrameworkCore;
using OpinionesClientes.Application.Interfaces;
using OpinionesClientes.Application.IRepositories.Api;
using OpinionesClientes.Application.IRepositories.Bd;
using OpinionesClientes.Application.IRepositories.Csv;
using OpinionesClientes.Application.IRepositories.Dwh;
using OpinionesClientes.Application.Services;
using OpinionesClientes.Persistence.Repositories.Api;
using OpinionesClientes.Persistence.Repositories.Bd;
using OpinionesClientes.Persistence.Repositories.Bd.Context;
using OpinionesClientes.Persistence.Repositories.Csv;
using OpinionesClientes.Persistence.Repositories.Dwh;
using OpinionesClientes.Persistence.Repositories.Dwh.Context;
using OpinionesCLientes.Domain.IRepositories;

namespace OpinionesClientes.WKSLoadDWH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddHostedService<Worker>();

            // Db extraccion
            builder.Services.AddDbContext<OPReviewsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));

            // Db DWH
            builder.Services.AddDbContext<DwhContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DwhDb")));

            //csv
            builder.Services.AddScoped<ICsvSurveysFileReaderRepository, CsvSurveysFileReaderRepository>();
            builder.Services.AddScoped(typeof(ICsvReaderRepository<>), typeof(CsvReaderRepository<>));
            
            //
            builder.Services.AddScoped<ICommentsApiRepository, CommentsApiRepository>();
            builder.Services.AddScoped<IDwhRepository, DwhRepository>();
            builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();

            builder.Services.AddScoped<IReviewsService, ReviewsService>();

            builder.Services.AddHttpClient("CommentsApiClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ApiConfig:BaseUrl"]!);
            });

            var host = builder.Build();
            host.Run();
        }
    }
}