namespace PokemonMasterAPI.Application.Interfaces
{
    public interface IRegisterTrainerUseCase
    {
        void RegisterTrainer(string name, int age, string cpf);
    }
}
