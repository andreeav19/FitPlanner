using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.ExerciseRepository
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(FitPlannerDbContext context) : base(context) { }

        public async Task<Exercise> UpdateAsync(Guid id, Exercise exercise)
        {
            var existingExercise = await GetByIdAsync(id);

            if (existingExercise == null)
            {
                return null;
            }

            existingExercise.Name = exercise.Name;
            existingExercise.Description = exercise.Description;
            existingExercise.Duration = exercise.Duration;

            await _context.SaveChangesAsync();

            return existingExercise;
        }
    }
}
