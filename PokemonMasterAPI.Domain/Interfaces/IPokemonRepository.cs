using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Domain.Interfaces
{
    public interface IPokemonRepository
    {
        Pokemon GetPokemonById(int id);
        List<Pokemon> GetRandomPokemons(int count);
    }
}
