using PokemonMasterAPI.Application.DTOs;

namespace PokemonMasterAPI.Domain.Entities
{
    public class PokemonListResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResultDto> Results { get; set; }
    }
}
