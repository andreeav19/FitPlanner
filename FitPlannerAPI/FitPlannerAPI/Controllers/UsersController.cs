using FitPlannerApi.Models;
using FitPlannerAPI.DTO.Users;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [Route("meals/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedMealsAsync(string username)
        {
            var meals = await _userService.GetAssociatedMealsAsync(username);

            if (meals.Count == 0)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        [HttpGet]
        [Route("workouts/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedWorkoutsAsync(string username)
        {
            var workouts = await _userService.GetAssociatedWorkoutsAsync(username);

            if (workouts.Count == 0)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> CreateUserAsync(UserPost userPost)
        {
            var userId = await _userService.CreateUserAsync(userPost);

            return CreatedAtAction(nameof(CreateUserAsync), userId);
        }

        [HttpPost]
        [Route("add-meal/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> AddMealAsync(string username, UserMealPost userMealPost)
        {
            var isAdded = await _userService.AddMealAsync(username, userMealPost);

            if (!isAdded)
            {
                return BadRequest("Could not add meal.");
            }

            return CreatedAtAction(nameof(AddMealAsync), isAdded);
        }

        [HttpPost]
        [Route("add-workout/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> AddWorkoutAsync(string username, UserWorkoutPost userWorkoutPost)
        {
            var isAdded = await _userService.AddWorkoutAsync(username, userWorkoutPost);

            if (!isAdded)
            {
                return BadRequest("Could not add workout.");
            }

            return CreatedAtAction(nameof(AddWorkoutAsync), isAdded);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUserAsync(UserLogin userLogin)
        {
            var token = await _userService.UserLoginAsync(userLogin);

            if (token == null)
            {
                return BadRequest("One of the fields username/password is incorrect.");
            }

            return Ok(token);
        }
    }
}
