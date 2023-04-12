

using AutoMapper;
using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Ingredients;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.IngredientRepository;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace FitPlannerAPI.Services.Ingredients
{
    public class IngredientSerivce : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientSerivce(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            this._ingredientRepository = ingredientRepository;
            this._mapper = mapper;
        }
        public async Task<Guid> CreateIngredientAsync(IngredientPost ingredientPost)
        {
            var ingredient = new FitPlannerAPI.Models.Models.Ingredient
            {
                Name = ingredientPost.Name,
                Calories = ingredientPost.Calories,
                Price = ingredientPost.Price,
                Quantity = ingredientPost.Quantity
            };

            var createdIngredientId = await _ingredientRepository.CreateAsyncGetId(ingredient);

            return createdIngredientId;
        }

        public async Task<bool> DeleteIngredientAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);

            if (ingredient == null)
            {
                return false;
            }

            await _ingredientRepository.DeleteAsync(ingredient);

            return true;
        }

        public async Task<List<FitPlannerAPI.DTO.Ingredients.Ingredient>> GetAllIngredientsAsync()
        {
            var ingredients = await _ingredientRepository.GetAllAsListAsync();
            var ingredientsDTO = _mapper.Map<List<FitPlannerAPI.DTO.Ingredients.Ingredient>>(ingredients);

            return ingredientsDTO;
        }

        public async Task<FitPlannerAPI.DTO.Ingredients.Ingredient> GetIngredientByIdAsync(Guid id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            var ingredientDTO = _mapper.Map<FitPlannerAPI.DTO.Ingredients.Ingredient>(ingredient);

            return ingredientDTO;
        }

        public async Task<FitPlannerAPI.DTO.Ingredients.Ingredient> UpdateIngredientAsync(Guid id, IngredientPut ingredientPut)
        {
            var ingredient = new FitPlannerAPI.Models.Models.Ingredient
            {
                Name = ingredientPut.Name,
                Calories = ingredientPut.Calories,
                Price = ingredientPut.Price,
                Quantity = ingredientPut.Quantity
            };

            ingredient = await _ingredientRepository.UpdateAsync(id, ingredient);

            if (ingredient == null)
            {
                return null;
            }

            var ingredientDTO = _mapper.Map<FitPlannerAPI.DTO.Ingredients.Ingredient>(ingredient);

            return ingredientDTO;
        }
    }
}
