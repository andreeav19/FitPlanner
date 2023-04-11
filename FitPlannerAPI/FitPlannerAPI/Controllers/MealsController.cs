using FitPlannerApi.Models;
using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.Services.Meals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealsController : Controller
    {
        private readonly IMealService _mealService;
        private readonly FitPlannerDbContext _context;

        public MealsController(IMealService mealService, FitPlannerDbContext context)
        {
            this._mealService = mealService;
            this._context = context;
        }

        [HttpGet]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAllMeals()
        {
            var meals = await _mealService.GetAllMeals();

            if (meals.Count == 0)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetMealById(Guid id)
        {
            var meal = await _mealService.GetMealById(id);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpGet]
        [Route("ingredients/{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedIngredients(Guid id)
        {
            var ingredients = await _mealService.GetIngredients(id);

            if (ingredients.Count == 0)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateMeal(MealPost mealPost)
        {
            var mealId = await _mealService.CreateMeal(mealPost);

            return CreatedAtAction(nameof(CreateMeal), mealId);
        }

        [HttpPost]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddIngredient(Guid id, MealIngredientPost mealIngredientPost)
        {
            var isAdded = await _mealService.AddIngredient(id, mealIngredientPost);

            if (!isAdded)
            {
                return BadRequest("Could not add ingredient.");
            }

            return CreatedAtAction(nameof(AddIngredient), isAdded);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMeal(Guid id, MealPut mealPut)
        {
            var meal = await _mealService.UpdateMeal(id, mealPut);

            if (meal == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(meal);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMeal(Guid id)
        {
            var isDeleted = await _mealService.DeleteMeal(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }
    }
}
