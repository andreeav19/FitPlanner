using FitPlannerAPI.DTO.Ingredients;
using FitPlannerAPI.Services.Ingredients;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAllIngredientsAsync()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();

            if (ingredients.Count == 0)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetIngredientByIdAsync(Guid id)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateIngredientAsync(IngredientPost ingredientPost)
        {
            var ingredientId = await _ingredientService.CreateIngredientAsync(ingredientPost);

            return CreatedAtAction(nameof(CreateIngredientAsync), ingredientId, ingredientId);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateIngredientAsync(Guid id, IngredientPut ingredientPut)
        {
            var ingredient = await _ingredientService.UpdateIngredientAsync(id, ingredientPut);

            if (ingredient == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(ingredient);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var isDeleted = await _ingredientService.DeleteIngredientAsync(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }

    }
}
