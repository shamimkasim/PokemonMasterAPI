namespace PokemonMasterAPI.Domain.Entities
{
    public class Capture
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int PokemonId { get; set; }
        public DateTime CaptureDate { get; set; }        
        public Trainer Trainer { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
