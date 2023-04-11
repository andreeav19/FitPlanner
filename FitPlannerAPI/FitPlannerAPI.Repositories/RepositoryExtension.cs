using FitPlannerAPI.Repositories.Repositories.ExerciseRepository;
using FitPlannerAPI.Repositories.Repositories.IngredientRepository;
using FitPlannerAPI.Repositories.Repositories.MealRepository;
using FitPlannerAPI.Repositories.Repositories.WorkoutRepository;
using Microsoft.Extensions.DependencyInjection;

namespace FitPlannerAPI.Repositories
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
        }
    }
}
