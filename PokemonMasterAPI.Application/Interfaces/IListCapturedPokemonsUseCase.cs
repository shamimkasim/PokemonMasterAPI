using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Application.Interfaces
{
    public interface IListCapturedPokemonsUseCase
    {
        List<Pokemon> GetCapturedPokemons(int trainerId);
    }
}
