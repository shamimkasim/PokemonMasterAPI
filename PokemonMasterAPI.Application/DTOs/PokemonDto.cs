namespace PokemonMasterAPI.Application.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Evolutions { get; set; }
        public List<CaptureDto> Captures { get; set; }
        public int TrainerId { get; set; }
        public int PokemonId { get; set; }
        public string SpriteBase64 { get; set; }
    }
}
