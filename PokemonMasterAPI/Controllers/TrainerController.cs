using Microsoft.AspNetCore.Mvc;
using PokemonMasterAPI.Application.UseCases;

namespace PokemonMasterAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly RegisterTrainerUseCase _registerTrainerUseCase;

        public TrainerController(RegisterTrainerUseCase registerTrainerUseCase)
        {
            _registerTrainerUseCase = registerTrainerUseCase;
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
    }
}
