using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Meals
{
    public interface IMealService
    {
        Task<List<Meal>> GetAllMeals();
        Task<Meal> GetMealById(Guid id);
        Task<Guid> CreateMeal(MealPost mealPost);
        Task<Meal> UpdateMeal(Guid id, MealPut mealPut);
        Task<bool> DeleteMeal(Guid id);
        Task<bool> AddIngredient(Guid mealId, MealIngredientPost mealIngredientPost);
        Task<List<AssociatedIngredient>> GetIngredients(Guid mealId);
    }
}
