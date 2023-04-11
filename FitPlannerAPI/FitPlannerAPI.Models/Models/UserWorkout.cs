namespace FitPlannerAPI.Models.Models
{
    public class UserWorkout
    {
        public Guid UserId { get; set; }
        public Guid WorkoutRoutineId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual WorkoutRoutine WorkoutRoutine { get; set; }
    }
}
