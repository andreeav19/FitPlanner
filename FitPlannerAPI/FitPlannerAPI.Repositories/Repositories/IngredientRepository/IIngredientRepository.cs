﻿using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.IngredientRepository
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        public Task<Ingredient> UpdateAsync(Guid id, Ingredient ingredient);

    }
}
