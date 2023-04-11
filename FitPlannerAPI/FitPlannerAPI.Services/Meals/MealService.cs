﻿using AutoMapper;
using FitPlannerAPI.DTO.Ingredients;
using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.MealRepository;

namespace FitPlannerAPI.Services.Meals
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public MealService(IMealRepository mealRepository, IMapper mapper)
        {
            this._mealRepository = mealRepository;
            this._mapper = mapper;
        }
        public async Task<bool> AddIngredient(Guid mealId, MealIngredientPost mealIngredientPost)
        {
            var mealIngredient = new FitPlannerAPI.Models.Models.MealIngredient
            {
                MealId = mealId,
                IngredientId = mealIngredientPost.IngredientId,
                IngredientCount = mealIngredientPost.IngredientCount
            };

            return await _mealRepository.CreateMealIngredient(mealIngredient);
        }

        public async Task<Guid> CreateMeal(MealPost mealPost)
        {
            var meal = new FitPlannerAPI.Models.Models.Meal
            {
                Name = mealPost.Name,
            };

            var createdMealId = await _mealRepository.CreateAsyncGetId(meal);

            return createdMealId;
        }

        public async Task<bool> DeleteMeal(Guid id)
        {
            var meal = await _mealRepository.GetByIdAsync(id);

            if (meal == null)
            {
                return false;
            }

            await _mealRepository.DeleteAsync(meal);

            return true;
        }

        public async Task<List<FitPlannerAPI.DTO.Meals.Meal>> GetAllMeals()
        {
            var meals = await _mealRepository.GetAllAsList();
            var mealsDTO = _mapper.Map<List<FitPlannerAPI.DTO.Meals.Meal>>(meals);

            return mealsDTO;
        }

        public async Task<List<AssociatedIngredient>> GetIngredients(Guid mealId)
        {
            var associatedIngredients = await _mealRepository.GetIngredientByMealId(mealId);
            List<AssociatedIngredient> ingredientsList = new List<AssociatedIngredient>();

            foreach (var i in associatedIngredients)
            {
                ingredientsList.Add(new AssociatedIngredient
                {
                    Id = i.IngredientId,
                    Name = i.Ingredient.Name,
                    Calories = i.Ingredient.Calories,
                    Price = i.Ingredient.Price,
                    Quantity = i.Ingredient.Quantity,
                    CreatedDate = i.Ingredient.CreatedDate,
                    UpdatedDate = i.Ingredient.UpdatedDate,
                    Count = i.IngredientCount
                });
            }

            return ingredientsList;
        }

        public async Task<FitPlannerAPI.DTO.Meals.Meal> GetMealById(Guid id)
        {
            var meal = await _mealRepository.GetByIdAsync(id);
            var mealDTO = _mapper.Map<FitPlannerAPI.DTO.Meals.Meal>(meal);

            return mealDTO;
        }

        public async Task<FitPlannerAPI.DTO.Meals.Meal> UpdateMeal(Guid id, MealPut mealPut)
        {
            var meal = new FitPlannerAPI.Models.Models.Meal
            {
                Name = mealPut.Name
            };

            meal = await _mealRepository.UpdateAsync(id, meal);

            if (meal == null)
            {
                return null;
            }

            var mealDTO = _mapper.Map<FitPlannerAPI.DTO.Meals.Meal>(meal);

            return mealDTO;
        }
    }
}
