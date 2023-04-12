using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(Guid id);
        Task<Guid> CreateIngredientAsync(IngredientPost ingredientPost);
        Task<Ingredient> UpdateIngredientAsync(Guid id, IngredientPut ingredientPut);
        Task<bool> DeleteIngredientAsync(Guid id);
    }
}
