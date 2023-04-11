namespace FitPlannerAPI.Models.Models
{
    public class UserMeal
    {
        public Guid UserId { get; set; }
        public Guid MealId { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
