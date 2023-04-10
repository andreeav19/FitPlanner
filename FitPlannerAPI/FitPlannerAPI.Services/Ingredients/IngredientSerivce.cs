

using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Ingredients;

namespace FitPlannerAPI.Services.Ingredients
{
    public class IngredientSerivce : IIngredientService
    {
        public Task<Guid> CreateIngredient(IngredientPost ingredientPost)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIngredient(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Exercise>> GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> GetIngredientById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Exercise> UpdateIngredient(Guid id, IngredientPut ingredientPut)
        {
            throw new NotImplementedException();
        }
    }
}
