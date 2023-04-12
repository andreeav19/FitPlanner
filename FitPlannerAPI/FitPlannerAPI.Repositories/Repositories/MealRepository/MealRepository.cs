using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerAPI.Repositories.Repositories.MealRepository
{
    public class MealRepository : BaseRepository<Meal>, IMealRepository
    {
        public MealRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public async Task<bool> CreateMealIngredientAsync(MealIngredient mealIngredient)
        {
            await _context.MealIngredients.AddAsync(mealIngredient);
            var entries = await _context.SaveChangesAsync();

            if (entries == 0 ) { return  false; }

            return true;
        }

        public async Task<List<MealIngredient>> GetIngredientByMealIdAsync(Guid mealId)
        {
            var ingredients = await _context.MealIngredients
                .Where(me => me.MealId == mealId)
                .Include(me => me.Ingredient)
                .ToListAsync();

            return ingredients;
        }

        public async Task<Meal> UpdateAsync(Guid id, Meal meal)
        {
            var existingMeal = await GetByIdAsync(id);

            if (existingMeal == null)
            {
                return null;
            }

            existingMeal.Name = meal.Name;

            await _context.SaveChangesAsync();

            return existingMeal;
        }
    }
}
