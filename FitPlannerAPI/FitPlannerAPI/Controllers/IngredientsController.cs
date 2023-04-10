using FitPlannerAPI.DTO.Ingredients;
using FitPlannerAPI.Services.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            this._ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIngredients()
        {
            var ingredients = await _ingredientService.GetAllIngredients();

            if (ingredients.Count == 0)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            var ingredient = await _ingredientService.GetIngredientById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(IngredientPost ingredientPost)
        {
            var ingredientId = await _ingredientService.CreateIngredient(ingredientPost);

            return Ok(ingredientId);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateIngredient(Guid id, IngredientPut ingredientPut)
        {
            var ingredient = await _ingredientService.UpdateIngredient(id, ingredientPut);

            if (ingredient == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(ingredient);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var isDeleted = await _ingredientService.DeleteIngredient(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }

    }
}
