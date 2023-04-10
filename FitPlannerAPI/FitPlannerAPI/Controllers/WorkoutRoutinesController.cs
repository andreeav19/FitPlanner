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
    }
}
