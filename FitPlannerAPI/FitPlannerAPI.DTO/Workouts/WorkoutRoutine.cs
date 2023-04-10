using FitPlannerAPI.DTO.Base;

namespace FitPlannerAPI.DTO.Workouts
{
    public class WorkoutRoutine : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Breaktime { get; set; }

    }
}
