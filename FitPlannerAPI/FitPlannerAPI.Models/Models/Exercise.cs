using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class Exercise : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; } // seconds

        // Navigation property
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }

    }
}
