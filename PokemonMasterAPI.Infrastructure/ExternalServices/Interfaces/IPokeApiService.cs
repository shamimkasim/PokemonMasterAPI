using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Infrastructure.ExternalServices.Interfaces
{
    public interface IPokeApiService
    {
        Task<string> GetPokemonSpriteBase64(int id);
        Task<PokemonInfo> GetPokemonInfo(int Id);
        Task<List<string>> GetPokemonEvolutions(string pokemonName);
        Task<List<Pokemon>> GetRandomPokemons(int limit);
        Task<List<Pokemon>> GetPokemons(int limit);
    }
}
