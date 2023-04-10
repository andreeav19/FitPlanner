using FitPlannerAPI.Services.Exercises;
using FitPlannerAPI.Services.Ingredients;
using Microsoft.Extensions.DependencyInjection;

namespace FitPlannerAPI.Services
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IIngredientService, IngredientSerivce>();
        }

    }
}