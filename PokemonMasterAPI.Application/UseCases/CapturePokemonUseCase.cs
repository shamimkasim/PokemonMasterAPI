using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Infrastructure.Data;

namespace PokemonMasterAPI.Application.UseCases
{
    public class CapturePokemonUseCase
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly PokemonDbContext _context;

        public CapturePokemonUseCase(IPokemonRepository pokemonRepository, PokemonDbContext context)
        {
            _pokemonRepository = pokemonRepository;
            _context = context;
        }

        public void CapturePokemon(int trainerId, int pokemonId)
        {
            var trainer = _trainerRepository.GetTrainerById(trainerId);
            var pokemon = _pokemonRepository.GetPokemonById(pokemonId);

            if (trainer != null && pokemon != null)
            {
                if (trainer.Captures.Exists(c => c.PokemonId == pokemonId))
                {
                    throw new Exception("This Pokémon is already captured by the trainer.");
                }

                var capture = new Capture
                {
                    TrainerId = trainerId,
                    PokemonId = pokemonId,
                    CaptureDate = DateTime.Now

                };

                _context.Captures.Add(capture);
                _context.SaveChanges();

            }
            else
            {
                throw new Exception("Invalid trainer ID or Pokémon ID.");
            }
        }
    }
}
