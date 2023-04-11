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
        public async Task<IActionResult> GetAllWorkoutRoutines()
        {
            var workouts = await _workoutService.GetAllWorkoutRoutines();

            if (workouts.Count == 0)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetWorkoutById(Guid id)
        {
            var workout = await _workoutService.GetWorkoutRoutineById(id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpGet]
        [Route("exercises/{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedExercises(Guid id)
        {
            var exercises = await _workoutService.GetExercises(id);

            if (exercises.Count == 0)
            {
                return NotFound();
            }

            return Ok(exercises);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateWorkoutRoutine(WorkoutRoutinePost workoutRoutinePost)
        {
            var workoutId = await _workoutService.CreateWorkoutRoutine(workoutRoutinePost);

            return CreatedAtAction(nameof(CreateWorkoutRoutine), workoutId, workoutId);
        }

        [HttpPost]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddExercise(Guid id, WorkoutExercisePost workoutExercisePost)
        {
            var isAdded = await _workoutService.AddExercise(id, workoutExercisePost);

            if (!isAdded) 
            { 
                return BadRequest("Could not add exercise."); 
            }

            return CreatedAtAction(nameof(AddExercise), isAdded, isAdded);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateWorkoutRoutine(Guid id, WorkoutRoutinePut workoutRoutinePut)
        {
            var workout = await _workoutService.UpdateWorkoutRoutine(id, workoutRoutinePut);

            if (workout == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(workout);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteWorkoutRoutine(Guid id)
        {
            var isDeleted = await _workoutService.DeleteWorkoutRoutine(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete.");
            }

            return Ok();
        }
    }
}
