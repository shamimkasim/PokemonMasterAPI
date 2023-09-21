using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Domain.Interfaces
{
    public interface IPokemonService
    {
        Pokemon GetPokemonById(int id);
    }
}
