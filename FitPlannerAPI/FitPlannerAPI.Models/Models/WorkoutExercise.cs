namespace FitPlannerAPI.Models.Models
{
    public class WorkoutExercise
    {
        public Guid WorkoutRoutineId { get; set; }
        public Guid ExerciseId { get; set; }
        public int ExerciseCount { get; set; }

        // Navigation properties
        public virtual Exercise Exercise { get; set; }
        public virtual WorkoutRoutine WorkoutRoutine { get; set; }
    }
}
