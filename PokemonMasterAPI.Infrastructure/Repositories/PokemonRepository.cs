using Microsoft.EntityFrameworkCore;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Infrastructure.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonDbContext _dbContext;

        public PokemonRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Pokemon GetPokemonById(int id)
        {
            var pokemon = _dbContext.Pokemons
                .Include(p => p.Evolutions)
                .FirstOrDefault(p => p.Id == id);

            return pokemon;
        }

        public List<Pokemon> GetRandomPokemons(int count)
        {
            return _dbContext.Pokemons.ToList();

        }       

    }
}
