using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserMeal> UserMeals { get; set; }
        public virtual ICollection<UserWorkout> UserWorkouts { get; set; }

    }
}
