using PokemonMasterAPI.Application.DTOs;

namespace PokemonMasterAPI.Application.Interfaces
{
    public interface ICapturePokemonUseCase
    {
        void CapturePokemon(int trainerId, int pokemonId);
        void CapturePokemon(PokemonDto pokemonDto);
    }
}
