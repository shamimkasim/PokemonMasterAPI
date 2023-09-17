
using Microsoft.AspNetCore.Mvc;
using PokemonMasterAPI.Application.UseCases;
using PokemonMasterAPI.Domain.Services;

namespace PokemonMasterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly RegisterTrainerUseCase _registerTrainerUseCase;
        private readonly TrainerService _trainerService;

        public TrainerController(RegisterTrainerUseCase registerTrainerUseCase, TrainerService trainerService)
        {
            _registerTrainerUseCase = registerTrainerUseCase;
            _trainerService = trainerService;
        }

        [HttpPost("RegisterTrainer")]
        public IActionResult RegisterTrainer(string name, int age, string cpf)
        {
            try
            {
                _registerTrainerUseCase.RegisterTrainer(name, age, cpf);
                return Ok("Trainer registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to register trainer: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("api/trainer/{id}")]
        public IActionResult GetTrainerById(int id)
        {
            try
            {
                var trainer = _trainerService.GetTrainerById(id);
                return Ok(trainer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
