using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<List<Exercise>> GetAllIngredients();
        Task<Exercise> GetIngredientById(Guid id);
        Task<Guid> CreateIngredient(IngredientPost ingredientPost);
        Task<Exercise> UpdateIngredient(Guid id, IngredientPut ingredientPut);
        Task<bool> DeleteIngredient(Guid id);
    }
}
