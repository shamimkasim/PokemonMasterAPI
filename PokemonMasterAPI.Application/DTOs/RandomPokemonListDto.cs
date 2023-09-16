namespace PokemonMasterAPI.Application.DTOs
{
    public class RandomPokemonListDto
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PokemonResultDto> Results { get; set; }
    }
}
