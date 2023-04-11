﻿using FitPlannerApi.Models;
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
        public async Task<IActionResult> GetAssociatedMeals(string username)
        {
            var meals = await _userService.GetAssociatedMeals(username);

            if (meals.Count == 0)
            {
                return NotFound();
            }

            return Ok(meals);
        }

        [HttpGet]
        [Route("workouts/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> GetAssociatedWorkouts(string username)
        {
            var workouts = await _userService.GetAssociatedWorkouts(username);

            if (workouts.Count == 0)
            {
                return NotFound();
            }

            return Ok(workouts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPost userPost)
        {
            var userId = await _userService.CreateUser(userPost);

            return CreatedAtAction(nameof(CreateUser), userId);
        }

        [HttpPost]
        [Route("add-meal/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> AddMeal(string username, UserMealPost userMealPost)
        {
            var isAdded = await _userService.AddMeal(username, userMealPost);

            if (!isAdded)
            {
                return BadRequest("Could not add meal.");
            }

            return CreatedAtAction(nameof(AddMeal), isAdded);
        }

        [HttpPost]
        [Route("add-workout/{username}")]
        [Authorize(Roles = "guest, admin")]
        public async Task<IActionResult> AddWorkout(string username, UserWorkoutPost userWorkoutPost)
        {
            var isAdded = await _userService.AddWorkout(username, userWorkoutPost);

            if (!isAdded)
            {
                return BadRequest("Could not add workout.");
            }

            return CreatedAtAction(nameof(AddWorkout), isAdded);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(UserLogin userLogin)
        {
            var token = await _userService.UserLogin(userLogin);

            if (token == null)
            {
                return BadRequest("One of the fields username/password is incorrect.");
            }

            return Ok(token);
        }
    }
}
