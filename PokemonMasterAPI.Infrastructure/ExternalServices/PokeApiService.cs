using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Infrastructure.ExternalServices
{
    public class PokeApiService : IPokeApiService
    {
        private readonly HttpClient _httpClient;

        public PokeApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }        
        public async Task<List<Pokemon>> GetPokemons( int limit)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon?&limit={limit}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic pokemonData = JsonConvert.DeserializeObject(responseBody);
            JArray results = pokemonData.results;

            List<Pokemon> pokemons = new List<Pokemon>();

            foreach (var result in results)
            {
                
                string url = result["url"].ToString();
                HttpResponseMessage pokemonResponse = await _httpClient.GetAsync(url);
                pokemonResponse.EnsureSuccessStatusCode();
                string pokemonResponseBody = await pokemonResponse.Content.ReadAsStringAsync();
                Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonResponseBody);
                pokemons.Add(pokemon);
            }

            return pokemons;
        }

        public async Task<string> GetPokemonSpriteBase64(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{id}");
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();           
            dynamic pokemonData = JsonConvert.DeserializeObject(responseBody);           
            string spriteBase64 = pokemonData.sprites.front_default;

            return spriteBase64;
        }
        public async Task<PokemonInfo> GetPokemonInfos(string pokemonName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{pokemonName}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            PokemonInfo pokemonInfo = JsonConvert.DeserializeObject<PokemonInfo>(responseBody);

            return pokemonInfo;
        }
        public async Task<Pokemon> GetPokemon(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody);
            return pokemon;
        }
        public async Task<Pokemon> GetPokemonLimit(int limit)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{limit}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody);

            return pokemon;
        }
        
        public async Task<List<string>> GetPokemonEvolutions(string pokemonName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon-species/{pokemonName}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic pokemonSpeciesData = JsonConvert.DeserializeObject(responseBody);
           
            string evolutionChainUrl = pokemonSpeciesData.evolution_chain.url;
            
            response = await _httpClient.GetAsync(evolutionChainUrl);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();

            dynamic evolutionChainData = JsonConvert.DeserializeObject(responseBody);

            List<string> evolutions = new List<string>();
            ParseEvolutionChain(evolutionChainData.chain, evolutions);

            return evolutions;
        }

        private void ParseEvolutionChain(dynamic chainNode, List<string> evolutions)
        {
            string pokemonName = chainNode.species.name;
            evolutions.Add(pokemonName);

            if (chainNode.evolves_to != null && chainNode.evolves_to.Count > 0)
            {
                foreach (var evolution in chainNode.evolves_to)
                {
                    ParseEvolutionChain(evolution, evolutions);
                }
            }
        }
        public async Task<string> GetPokemonSpriteBase64(string pokemonName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{pokemonName}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic pokemonData = JsonConvert.DeserializeObject(responseBody);
            string spriteBase64 = pokemonData.sprites.front_default;

            return spriteBase64;
        }
        public async Task<PokemonInfo> GetPokemonInfo(int Id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon/{Id}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic pokemonData = JsonConvert.DeserializeObject(responseBody);

            PokemonInfo pokemonInfo = new PokemonInfo
            {
                Name = pokemonData.name,
                Url = $"https://pokeapi.co/api/v2/pokemon/{pokemonData.Id}/"
            };

            return pokemonInfo;
        }
        public async Task<List<PokemonInfo>> GetPokemonList(int offset, int limit)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"pokemon?offset={offset}&limit={limit}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic pokemonListData = JsonConvert.DeserializeObject(responseBody);

            List<PokemonInfo> pokemonList = new List<PokemonInfo>();

            foreach (var result in pokemonListData.results)
            {
                pokemonList.Add(new PokemonInfo
                {
                    Name = result.name,
                    Url = result.url
                });
            }

            return pokemonList;
        }


    }
}
