namespace FitPlannerAPI.Models.Models
{
    public class UserWorkout
    {
        public Guid UserId { get; set; }
        public Guid WorkoutId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
