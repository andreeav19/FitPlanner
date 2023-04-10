using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.IngredientRepository
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public async Task<Ingredient> UpdateAsync(Guid id, Ingredient ingredient)
        {
            var existingIngredient = await GetByIdAsync(id);

            if (existingIngredient == null)
            {
                return null;
            }

            existingIngredient.Name = ingredient.Name;
            existingIngredient.Calories = ingredient.Calories;
            existingIngredient.Price = ingredient.Price;
            existingIngredient.Quantity = ingredient.Quantity;

            await _context.SaveChangesAsync();

            return existingIngredient;
        }
    }
}
