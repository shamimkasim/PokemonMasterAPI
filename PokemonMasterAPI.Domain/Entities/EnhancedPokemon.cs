namespace PokemonMasterAPI.Domain.Entities
{
    public class EnhancedPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<string> Evolutions { get; set; }
        public string SpriteBase64 { get; set; }
    }
}
