
using Microsoft.EntityFrameworkCore;
using OpinionesClientes.API.Data.Context;
using OpinionesClientes.API.Data.Interfaces;
using OpinionesClientes.API.Data.Repositories;

namespace OpinionesClientes.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<OPCommentsContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));

            builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();

            
            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
