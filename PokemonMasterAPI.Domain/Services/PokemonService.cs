using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace PokemonMasterAPI.Domain.Services
{
    public class PokemonService
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
