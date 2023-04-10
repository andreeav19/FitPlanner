using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerAPI.Repositories.Repositories.WorkoutRepository
{
    public class WorkoutRepository : BaseRepository<WorkoutRoutine>, IWorkoutRepository
    {
        public WorkoutRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public async Task<WorkoutRoutine> UpdateAsync(Guid id, WorkoutRoutine workoutRoutine)
        {
            var existingWorkout = await GetByIdAsync(id);

            if (existingWorkout == null)
            {
                return null;
            }

            existingWorkout.Name = workoutRoutine.Name;
            existingWorkout.Description = workoutRoutine.Description;
            existingWorkout.Breaktime = workoutRoutine.Breaktime;

            await _context.SaveChangesAsync();

            return existingWorkout;
        }

        public async Task<List<WorkoutRoutine>> GetWorkoutRoutineExercises()
        {
            return await _table
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .ToListAsync();
        }
    }
}
