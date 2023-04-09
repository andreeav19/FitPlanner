namespace FitPlannerAPI.Models.Models
{
    public class MealIngredient
    {
        public Guid MealId { get; set; }
        public Guid IngredientId { get; set; }
        public int IngredientCount { get; set; }

        // Navigation properties
        public virtual Meal Meal { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
