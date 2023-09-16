using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Domain.Interfaces
{
    public interface IPokeApiService
    {
        Task<string> GetPokemonSpriteBase64(int id);
        Task<PokemonInfo> GetPokemonInfo(int Id);
        Task<List<string>> GetPokemonEvolutions(string pokemonName);
    }

}
