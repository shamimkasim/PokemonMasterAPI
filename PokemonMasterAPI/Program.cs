using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Domain.Services;
using PokemonMasterAPI.Infrastructure.Data;
using PokemonMasterAPI.Infrastructure.Data.Repositories;
using PokemonMasterAPI.Infrastructure.ExternalServices;

namespace PokemonMasterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<RegisterTrainerUseCase>();
            builder.Services.AddScoped<IPokeApiService, PokeApiService>();
            builder.Services.AddScoped<GetPokemonUseCase>();
            builder.Services.AddScoped<CapturePokemonUseCase>();
            builder.Services.AddScoped<ListCapturedPokemonsUseCase>();
            builder.Services.AddScoped<PokeApiService>();
            builder.Services.AddScoped<PokemonService>();
            builder.Services.AddScoped<GetRandomPokemonsUseCase>();
            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
            builder.Services.AddScoped<TrainerService>();
            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
            builder.Services.AddDbContext<PokemonDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon Master API", Version = "v1" });
            });
            var app = builder.Build();

            // Migrate the database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PokemonDbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger UI in development mode
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon Master API v1");
                    //c.RoutePrefix = string.Empty; // Serve the Swagger UI at the root
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

    }
}
