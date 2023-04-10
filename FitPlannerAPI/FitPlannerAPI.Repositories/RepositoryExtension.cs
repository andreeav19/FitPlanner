using FitPlannerAPI.Repositories.Repositories.ExerciseRepository;
using FitPlannerAPI.Repositories.Repositories.IngredientRepository;
using Microsoft.Extensions.DependencyInjection;

namespace FitPlannerAPI.Repositories
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
        }
    }
}
