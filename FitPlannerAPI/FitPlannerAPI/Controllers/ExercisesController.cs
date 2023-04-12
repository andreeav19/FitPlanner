using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.Services.Exercises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this._exerciseService = exerciseService;
        }

        [HttpGet]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAllExercisesAsync() { 
            var exercises = await _exerciseService.GetAllExercisesAsync();

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetExerciseByIdAsync(Guid id)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateExerciseAsync(ExercisePost exercisePost)
        {
            var exerciseId = await _exerciseService.CreateExerciseAsync(exercisePost);

            return CreatedAtAction(nameof(CreateExerciseAsync), exerciseId, exerciseId);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateExerciseAsync(Guid id, ExercisePut exercisePut)
        {
            var exercise = await _exerciseService.UpdateExerciseAsync(id, exercisePut);

            if (exercise == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(exercise);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteExerciseAsync(Guid id)
        {
            var isDeleted = await _exerciseService.DeleteExerciseAsync(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }
    }
}
