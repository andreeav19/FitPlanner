using FitPlannerAPI.Services.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this._exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises() { 
            var exercises = await _exerciseService.GetAllExercises();

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }
    }
}
