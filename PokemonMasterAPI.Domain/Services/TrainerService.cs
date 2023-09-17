using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Domain.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository ?? throw new ArgumentNullException(nameof(trainerRepository));
        }

        public void RegisterTrainer(string name, int age, string cpf)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            if (age <= 0)
            {
                throw new ArgumentException("Age must be a positive integer.", nameof(age));
            }

            if (string.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("CPF number cannot be null or empty.", nameof(cpf));
            }

            _trainerRepository.RegisterTrainer(name, age, cpf);
        }

        public Trainer GetTrainerById(int id)
        {
            var trainer = _trainerRepository.GetTrainerById(id);
            return trainer;
        }

        public List<Pokemon> GetCapturedPokemons(int trainerId)
        {
            if (trainerId <= 0)
            {
                throw new ArgumentException("Invalid trainer ID.", nameof(trainerId));
            }

            return _trainerRepository.GetCapturedPokemons(trainerId);
        }

      
    }
}
