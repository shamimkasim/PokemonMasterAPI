using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Application.Interfaces
{

    public interface IGetPokemonUseCase
    {
        Pokemon GetPokemon(int id);
    }
}
