using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Application.UseCases
{
    public class GetRandomPokemonsUseCase: IGetRandomPokemonsUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetRandomPokemonsUseCase(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository ?? throw new ArgumentNullException(nameof(pokemonRepository));
        }
        public List<Pokemon> GetRandomPokemons(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count must be a positive integer.", nameof(count));
            }

            return _pokemonRepository.GetRandomPokemons(count);
        }
        
    }
}
