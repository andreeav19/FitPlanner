using FitPlannerApi.Models;
using FitPlannerAPI.DTO.Workouts;
using FitPlannerAPI.Services.Workouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IWorkoutRoutineService _workoutService;
        private readonly FitPlannerDbContext fitPlannerDbContext;

        public WorkoutRoutinesController(IWorkoutRoutineService workoutService, FitPlannerDbContext fitPlannerDbContext)
        {
            this._workoutService = workoutService;
            this.fitPlannerDbContext = fitPlannerDbContext;
        }

        [HttpGet]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAllWorkoutRoutinesAsync()
        {
            var workouts = await _workoutService.GetAllWorkoutRoutinesAsync();

            if (workouts.Count == 0)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetWorkoutByIdAsync(Guid id)
        {
            var workout = await _workoutService.GetWorkoutRoutineByIdAsync(id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpGet]
        [Route("exercises/{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedExercisesAsync(Guid id)
        {
            var exercises = await _workoutService.GetExercisesAsync(id);

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        [HttpPost]
        [Route("create-workout")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateWorkoutRoutineAsync(WorkoutRoutinePost workoutRoutinePost)
        {
            var workoutId = await _workoutService.CreateWorkoutRoutineAsync(workoutRoutinePost);

            return CreatedAtAction(nameof(CreateWorkoutRoutineAsync), workoutId, workoutId);
        }

        [HttpPost]
        [Route("add-exercise/{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddExerciseAsync(Guid id, WorkoutExercisePost workoutExercisePost)
        {
            var isAdded = await _workoutService.AddExerciseAsync(id, workoutExercisePost);

            if (!isAdded) 
            { 
                return BadRequest("Could not add exercise."); 
            }

            return CreatedAtAction(nameof(AddExerciseAsync), isAdded, isAdded);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateWorkoutRoutineAsync(Guid id, WorkoutRoutinePut workoutRoutinePut)
        {
            var workout = await _workoutService.UpdateWorkoutRoutineAsync(id, workoutRoutinePut);

            if (workout == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(workout);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteWorkoutRoutineAsync(Guid id)
        {
            var isDeleted = await _workoutService.DeleteWorkoutRoutineAsync(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete.");
            }

            return Ok();
        }
    }
}
