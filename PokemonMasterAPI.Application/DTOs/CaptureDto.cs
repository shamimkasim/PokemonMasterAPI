namespace PokemonMasterAPI.Application.DTOs
{
    public class CaptureDto
    {
        public int Id { get; set; }
        public DateTime CaptureDate { get; set; }
        public int TrainerId { get; set; }
    }
}
