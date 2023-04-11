using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.WorkoutRepository
{
    public interface IWorkoutRepository : IBaseRepository<WorkoutRoutine>
    {
        public Task<WorkoutRoutine> UpdateAsync(Guid id, WorkoutRoutine workoutRoutine);
        public Task<bool> CreateWorkoutExercise(WorkoutExercise workoutExercise);
        public Task<List<WorkoutExercise>> GetExerciseByWorkoutId(Guid workoutId);

    }
}
