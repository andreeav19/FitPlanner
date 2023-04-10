using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.ExerciseRepository
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        public Task<Exercise> UpdateAsync(Guid id, Exercise exercise);
    }
}
