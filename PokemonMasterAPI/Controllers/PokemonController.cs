using Microsoft.AspNetCore.Mvc;
using PokemonMasterAPI.Application.DTOs;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Infrastructure.ExternalServices;

namespace PokemonMasterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly GetRandomPokemonsUseCase _getRandomPokemonsUseCase;
        private readonly GetPokemonUseCase _getPokemonUseCase;
        private readonly CapturePokemonUseCase _capturePokemonUseCase;
        private readonly ListCapturedPokemonsUseCase _listCapturedPokemonsUseCase;
        private readonly PokeApiService _pokeApiService;

        public PokemonController(
            GetRandomPokemonsUseCase getRandomPokemonsUseCase,
            GetPokemonUseCase getPokemonUseCase,
            CapturePokemonUseCase capturePokemonUseCase,
            ListCapturedPokemonsUseCase listCapturedPokemonsUseCase,
            PokeApiService pokeApiService)
        {
            _getRandomPokemonsUseCase = getRandomPokemonsUseCase;
            _getPokemonUseCase = getPokemonUseCase;
            _capturePokemonUseCase = capturePokemonUseCase;
            _listCapturedPokemonsUseCase = listCapturedPokemonsUseCase;
            _pokeApiService = pokeApiService;
        }

      
        [HttpGet("GetRandomPokemons/{count}")]
        public IActionResult GetRandomPokemons(int count)
        {
            try
            {
                var enhancedPokemons = _getRandomPokemonsUseCase.GetRandomPokemons(count);
                return Ok(enhancedPokemons);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve random Pokémon: {ex.Message}");
            }
        }


        [HttpGet("GetPokemon")]
        public async Task<Pokemon> GetPokemon(int id)
        {
            return await _pokeApiService.GetPokemon(id);
        }

        [HttpPost("CapturePokemon")]
        public IActionResult CapturePokemon(int trainerId, int pokemonId)
        {
            try
            {
                _capturePokemonUseCase.CapturePokemon(trainerId, pokemonId);
                return Ok("Pokemon captured successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to capture Pokemon: {ex.Message}");
            }
        }

        [HttpGet("ListCapturedPokemons")]
        public List<Pokemon> ListCapturedPokemons(int trainerId)
        {
            return _listCapturedPokemonsUseCase.GetCapturedPokemons(trainerId);
        }

        

        [HttpGet("GetRandomPokemons")]
        public IActionResult GetRandomPokemons([FromQuery] int? count)
        {
            try
            {
                var enhancedPokemons = _getRandomPokemonsUseCase.GetRandomPokemons(count ?? 5);
                return Ok(enhancedPokemons);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve random Pokémon: {ex.Message}");
            }
        }

       
        [HttpGet("GetPokemons")]
        public async  Task <IActionResult> GetPokemons( int limit)
        {            
            List<Pokemon> pokemons = await _pokeApiService.GetPokemons( limit);

            List<PokemonResultDto> pokemonResults = pokemons.Select(p => new PokemonResultDto
            {
                Name = p.Name,
                Url = $"https://pokeapi.co/api/v2/pokemon/{p.Id}/"
            }).ToList();
            return Ok(pokemonResults);
        }
        [HttpGet("GetPokemonList")]
        public IActionResult GetPokemonList(int offset, int limit)
        {           

            var response = new
            {
                count = 1281,
                next = $"https://pokeapi.co/api/v2/pokemon?offset={offset + limit}&limit={limit}",
                previous = offset - limit >= 0 ? $"https://pokeapi.co/api/v2/pokemon?offset={offset - limit}&limit={limit}" : null,
                results = new[]
                {
            new
            {
                name = "bulbasaur",
                url = $"https://pokeapi.co/api/v2/pokemon/{limit}/"
            },
           
        }
            };

            return Ok(response);
        }


    }
}