using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PokemonMasterAPI.Domain.Entities;
using PokemonMasterAPI.Domain.Interfaces;

namespace PokemonMasterAPI.Infrastructure.Data.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly PokemonDbContext _dbContext;

        public TrainerRepository(PokemonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegisterTrainer(string name, int age, string cpf)
        {
            var trainer = new Trainer
            {
                Name = name,
                Age = age,
                CPF = cpf
            };

            _dbContext.Trainers.Add(trainer);
            _dbContext.SaveChanges();
        }

        public List<Pokemon> GetCapturedPokemons(int trainerId)
        {
            return _dbContext.Trainers
                .Include(t => t.CapturedPokemons)
                .Where(t => t.Id == trainerId)
                .SelectMany(t => t.CapturedPokemons)
                .ToList();
        }

        public void UpdateTrainer(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            _dbContext.SaveChanges();
        }

        public Trainer GetTrainerById(int trainerId)
        {
            return _dbContext.Trainers.FirstOrDefault(t => t.Id == trainerId);
        }

        public void CapturePokemon(int trainerId, int pokemonId)
        {
            var trainer = GetTrainerById(trainerId);
            var pokemon = _dbContext.Pokemons.FirstOrDefault(p => p.Id == pokemonId);

            if (trainer != null && pokemon != null)
            {               
                if (trainer.CapturedPokemons.Any(p => p.Id == pokemonId))
                {
                    throw new Exception("This Pokémon is already captured by the trainer.");
                }
                
                trainer.CapturedPokemons.Add(pokemon);               
                UpdateTrainer(trainer);               
            }
            else
            {
                throw new Exception("Invalid trainer ID or Pokémon ID.");
            }
        }
    }
}
