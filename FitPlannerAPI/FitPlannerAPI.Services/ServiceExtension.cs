using FitPlannerAPI.Services.Exercises;
using Microsoft.Extensions.DependencyInjection;

namespace FitPlannerAPI.Services
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExerciseService, ExerciseService>();
        }

    }
}