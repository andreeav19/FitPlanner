using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllIngredients();
        Task<Ingredient> GetIngredientById(Guid id);
        Task<Guid> CreateIngredient(IngredientPost ingredientPost);
        Task<Ingredient> UpdateIngredient(Guid id, IngredientPut ingredientPut);
        Task<bool> DeleteIngredient(Guid id);
    }
}
