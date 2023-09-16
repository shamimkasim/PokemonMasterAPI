namespace PokemonMasterAPI.Domain.Entities
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public List<Pokemon> CapturedPokemons { get; set; } = new List<Pokemon>();
        public List<Capture> Captures { get; set; }

    }
}
