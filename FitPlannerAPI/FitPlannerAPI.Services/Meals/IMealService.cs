using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Meals
{
    public interface IMealService
    {
        Task<List<Meal>> GetAllMealsAsync();
        Task<Meal> GetMealByIdAsync(Guid id);
        Task<Guid> CreateMealAsync(MealPost mealPost);
        Task<Meal> UpdateMealAsync(Guid id, MealPut mealPut);
        Task<bool> DeleteMealAsync(Guid id);
        Task<bool> AddIngredientAsync(Guid mealId, MealIngredientPost mealIngredientPost);
        Task<List<AssociatedIngredient>> GetIngredientsAsync(Guid mealId);
    }
}
