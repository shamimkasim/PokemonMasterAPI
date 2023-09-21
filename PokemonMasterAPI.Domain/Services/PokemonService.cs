using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Domain.Services
{
    public class PokemonService: IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public List<Pokemon> GetRandomPokemons(int count)
        {
            return _pokemonRepository.GetRandomPokemons(count);
        }

        public Pokemon GetPokemonById(int id)
        {
            return _pokemonRepository.GetPokemonById(id);
        }
    }
}
