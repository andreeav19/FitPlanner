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
        public async Task<IActionResult> GetAllMealsAsync()
        {
            var meals = await _mealService.GetAllMealsAsync();

            if (meals.Count == 0)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetMealByIdAsync(Guid id)
        {
            var meal = await _mealService.GetMealByIdAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpGet]
        [Route("ingredients/{id:guid}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedIngredientsAsync(Guid id)
        {
            var ingredients = await _mealService.GetIngredientsAsync(id);

            if (ingredients.Count == 0)
            {
                return NotFound();
            }

            return Ok(ingredients);
        }

        [HttpPost]
        [Route("create-meal")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateMealAsync(MealPost mealPost)
        {
            var mealId = await _mealService.CreateMealAsync(mealPost);

            return CreatedAtAction(nameof(CreateMealAsync), mealId);
        }

        [HttpPost]
        [Route("add-ingredient/{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddIngredientAsync(Guid id, MealIngredientPost mealIngredientPost)
        {
            var isAdded = await _mealService.AddIngredientAsync(id, mealIngredientPost);

            if (!isAdded)
            {
                return BadRequest("Could not add ingredient.");
            }

            return CreatedAtAction(nameof(AddIngredientAsync), isAdded);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateMealAsync(Guid id, MealPut mealPut)
        {
            var meal = await _mealService.UpdateMealAsync(id, mealPut);

            if (meal == null)
            {
                return BadRequest("Could not update.");
            }

            return Ok(meal);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteMealAsync(Guid id)
        {
            var isDeleted = await _mealService.DeleteMealAsync(id);

            if (!isDeleted)
            {
                return BadRequest("Could not delete");
            }

            return Ok();
        }
    }
}
