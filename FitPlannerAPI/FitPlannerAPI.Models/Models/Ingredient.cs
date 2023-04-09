using FitPlannerAPI.Models.Base;

namespace FitPlannerAPI.Models.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public int Calories { get; set; } // calories per gram
        public float Price { get; set; } // euros
        public int Quantity { get; set; } // grams

        // Navigation property
        public virtual ICollection<MealIngredient> MealIngredients { get; set; }
    }
}
