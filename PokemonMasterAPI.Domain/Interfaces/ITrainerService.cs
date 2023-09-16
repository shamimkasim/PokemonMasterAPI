using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Domain.Interfaces
{
    public interface ITrainerService
    {
        void RegisterTrainer(string name, int age, string cpf);
        List<Pokemon> GetCapturedPokemons(int trainerId);
    }
}
