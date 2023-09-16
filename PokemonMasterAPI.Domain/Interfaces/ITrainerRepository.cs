using PokemonMasterAPI.Domain.Entities;

namespace PokemonMasterAPI.Domain.Interfaces
{
    public interface ITrainerRepository
    {
        void RegisterTrainer(string name, int age, string cpf);
        List<Pokemon> GetCapturedPokemons(int trainerId);
        void UpdateTrainer(Trainer trainer);
        Trainer GetTrainerById(int trainerId);
        void CapturePokemon(int trainerId, int pokemonId);
    }

}
