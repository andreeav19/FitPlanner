using FitPlannerAPI.DTO.Base;
using FitPlannerAPI.Models.Models;

namespace FitPlannerAPI.DTO.Workouts
{
    public class WorkoutRoutine : BaseDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Breaktime { get; set; }

    }
}
