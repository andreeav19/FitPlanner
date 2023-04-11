using FitPlannerAPI.Services.Exercises;
using FitPlannerAPI.Services.Ingredients;
using FitPlannerAPI.Services.Meals;
using FitPlannerAPI.Services.Workouts;
using Microsoft.Extensions.DependencyInjection;

namespace FitPlannerAPI.Services
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IIngredientService, IngredientSerivce>();
            services.AddScoped<IWorkoutRoutineService, WorkoutRoutineService>();
            services.AddScoped<IMealService, MealService>();
        }

    }
}