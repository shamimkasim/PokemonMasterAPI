using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Domain.Services;
using PokemonMasterAPI.Infrastructure.Data;
using PokemonMasterAPI.Infrastructure.Data.Repositories;
using PokemonMasterAPI.Infrastructure.ExternalServices;
using IPokeApiService = PokemonMasterAPI.Infrastructure.ExternalServices.Interfaces.IPokeApiService;

namespace PokemonMasterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IRegisterTrainerUseCase,RegisterTrainerUseCase>();
           
            builder.Services.AddScoped<IGetPokemonUseCase ,GetPokemonUseCase>();
            builder.Services.AddScoped<ICapturePokemonUseCase,CapturePokemonUseCase>();
            builder.Services.AddScoped<IListCapturedPokemonsUseCase,ListCapturedPokemonsUseCase>();
            builder.Services.AddScoped<IPokeApiService,PokeApiService>();
            builder.Services.AddScoped<PokemonService>();
            builder.Services.AddScoped<IGetRandomPokemonsUseCase ,GetRandomPokemonsUseCase>();
            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
            builder.Services.AddScoped<ITrainerService ,TrainerService>();
            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
            builder.Services.AddDbContext<PokemonDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon Master API", Version = "v1" });
            });
            var app = builder.Build();
           
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PokemonDbContext>();
                context.Database.Migrate();
            }
            
            if (app.Environment.IsDevelopment())
            {               
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pokemon Master API v1");
                   
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

    }
}
