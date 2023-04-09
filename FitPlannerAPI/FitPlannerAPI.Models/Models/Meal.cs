using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<MealIngredient> MealIngredients { get; set; }
    }
}
