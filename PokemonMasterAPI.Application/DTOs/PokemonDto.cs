namespace PokemonMasterAPI.Application.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Evolutions { get; set; }
        public string SpriteBase64 { get; set; }
    }
}
