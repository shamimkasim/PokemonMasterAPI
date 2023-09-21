using PokemonMasterAPI.Application.Interfaces;
using PokemonMasterAPI.Domain.Interfaces;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Application.UseCases
{
    public class RegisterTrainerUseCase: IRegisterTrainerUseCase
    {
        private readonly ITrainerService _trainerService;

        public RegisterTrainerUseCase(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        public void RegisterTrainer(string name, int age, string cpf)
        {
            _trainerService.RegisterTrainer(name, age, cpf);
        }
    }
}
