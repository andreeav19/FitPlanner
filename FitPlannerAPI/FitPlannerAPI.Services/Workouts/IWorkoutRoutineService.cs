using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Workouts;

namespace FitPlannerAPI.Services.Workouts
{
    public interface IWorkoutRoutineService
    {
        Task<List<WorkoutRoutine>> GetAllWorkoutRoutinesAsync();
        Task<WorkoutRoutine> GetWorkoutRoutineByIdAsync(Guid id);
        Task<Guid> CreateWorkoutRoutineAsync(WorkoutRoutinePost workoutRoutinePost);
        Task<WorkoutRoutine> UpdateWorkoutRoutineAsync(Guid id, WorkoutRoutinePut workoutRoutinePut);
        Task<bool> DeleteWorkoutRoutineAsync(Guid id);
        Task<bool> AddExerciseAsync(Guid workoutId, WorkoutExercisePost workoutExercisePost);
        Task<List<AssociatedExercise>> GetExercisesAsync(Guid workoutId);
    }
}
