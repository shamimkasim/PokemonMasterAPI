using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class RegisterTrainerUseCase: IRegisterTrainerUseCase
    {
        private readonly TrainerService _trainerService;

        public RegisterTrainerUseCase(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public void RegisterTrainer(string name, int age, string cpf)
        {
            _trainerService.RegisterTrainer(name, age, cpf);
        }
    }
}
