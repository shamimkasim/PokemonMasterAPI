using System.ComponentModel.DataAnnotations;

namespace PokemonMasterAPI.Domain.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Capture> Captures { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public List<Evolution> Evolutions { get; set; }

    }
}