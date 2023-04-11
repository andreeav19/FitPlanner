using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<MealIngredient> MealIngredients { get; set; }
        public virtual ICollection<UserMeal> UserMeals { get; set; }

    }
}
