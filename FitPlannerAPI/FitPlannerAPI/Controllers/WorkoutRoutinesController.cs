using FitPlannerAPI.DTO.Workouts;
using FitPlannerAPI.Services.Workouts;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutRoutinesController : Controller
    {
        private readonly IWorkoutRoutineService _workoutService;

        public WorkoutRoutinesController(IWorkoutRoutineService workoutService)
        {
            this._workoutService = workoutService;
        }

        [HttpGet]
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
        public async Task<IActionResult> GetWorkoutById(Guid id)
        {
            var workout = await _workoutService.GetWorkoutRoutineById(id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutRoutine(WorkoutRoutinePost workoutRoutinePost)
        {
            var workoutId = await _workoutService.CreateWorkoutRoutine(workoutRoutinePost);

            return Ok(workoutId);
        }

        [HttpPut]
        [Route("{id:guid}")]
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
