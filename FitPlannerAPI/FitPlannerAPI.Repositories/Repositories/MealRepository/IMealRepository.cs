using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.MealRepository
{
    public interface IMealRepository : IBaseRepository<Meal>
    {
        public Task<Meal> UpdateAsync(Guid id, Meal meal);
        public Task<bool> CreateMealIngredientAsync(MealIngredient mealIngredient);
        public Task<List<MealIngredient>> GetIngredientByMealIdAsync(Guid mealId);
    }
}
