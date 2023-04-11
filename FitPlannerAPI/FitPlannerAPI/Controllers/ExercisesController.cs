using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.Services.Exercises;
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
        public async Task<IActionResult> GetAllExercises() { 
            var exercises = await _exerciseService.GetAllExercises();

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetExerciseById(Guid id)
        {
            var exercise = await _exerciseService.GetExerciseById(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(ExercisePost exercisePost)
        {
            var exerciseId = await _exerciseService.CreateExercise(exercisePost);

            return CreatedAtAction(nameof(CreateExercise), exerciseId, exerciseId);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateExercise(Guid id, ExercisePut exercisePut)
        {
            var exercise = await _exerciseService.UpdateExercise(id, exercisePut);

            if (exercise == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(exercise);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            var isDeleted = await _exerciseService.DeleteExercise(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }
    }
}
