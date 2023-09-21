using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Application.Interfaces
{
    public interface IGetRandomPokemonsUseCase
    {
        List<Pokemon> GetRandomPokemons(int count);
    }
}
