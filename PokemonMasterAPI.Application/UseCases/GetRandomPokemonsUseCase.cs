using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Application.UseCases
{
    public class GetRandomPokemonsUseCase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokeApiService _pokeApiService;

        public GetRandomPokemonsUseCase(IPokemonRepository pokemonRepository, IPokeApiService pokeApiService)
        {
            _pokemonRepository = pokemonRepository;
            _pokeApiService = pokeApiService;
        }

        public async Task<List<EnhancedPokemon>> GetRandomPokemons(int count)
        {
            var randomPokemons = _pokemonRepository.GetRandomPokemons(count);
            var enhancedPokemons = new List<EnhancedPokemon>();

            foreach (var pokemon in randomPokemons)
            {
                var evolutions = await _pokeApiService.GetPokemonEvolutions(pokemon.Name);
                var spriteBase64 = await _pokeApiService.GetPokemonSpriteBase64(pokemon.Id);

                var enhancedPokemon = new EnhancedPokemon
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight,
                    Evolutions = evolutions,
                    SpriteBase64 = spriteBase64
                };

                enhancedPokemons.Add(enhancedPokemon);
            }

            return enhancedPokemons;
        }
    }
}
