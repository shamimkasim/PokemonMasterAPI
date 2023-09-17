using PokemonMasterAPI.Application.DTOs;
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

        public CapturePokemonUseCase(ITrainerRepository trainerRepository, IPokemonRepository pokemonRepository, PokemonDbContext context) // Add trainerRepository parameter
        {
            _trainerRepository = trainerRepository; 
            _pokemonRepository = pokemonRepository;
            _context = context;
        }

       

        public void CapturePokemon(int trainerId, int pokemonId)
        {
            var trainer = _trainerRepository.GetTrainerById(trainerId);
            var pokemon = _pokemonRepository.GetPokemonById(pokemonId);

            if (trainer != null && pokemon != null)
            {
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

        public void CapturePokemon(PokemonDto pokemonDto)
        {
            var trainer = _trainerRepository.GetTrainerById(pokemonDto.TrainerId);
            var pokemon = _pokemonRepository.GetPokemonById(pokemonDto.PokemonId);

            if (trainer != null && pokemon != null)
            {                

                var capture = new Capture
                {
                    TrainerId = pokemonDto.TrainerId,
                    PokemonId = pokemonDto.PokemonId,
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

