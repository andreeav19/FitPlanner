using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Workouts;

namespace FitPlannerAPI.Services.Workouts
{
    public interface IWorkoutRoutineService
    {
        Task<List<WorkoutRoutine>> GetAllWorkoutRoutines();
        Task<WorkoutRoutine> GetWorkoutRoutineById(Guid id);
        Task<Guid> CreateWorkoutRoutine(WorkoutRoutinePost workoutRoutinePost);
        Task<WorkoutRoutine> UpdateWorkoutRoutine(Guid id, WorkoutRoutinePut workoutRoutinePut);
        Task<bool> DeleteWorkoutRoutine(Guid id);
        Task<bool> AddExercise(Guid workoutId, WorkoutExercisePost workoutExercisePost);
        Task<List<AssociatedExercise>> GetExercises(Guid workoutId);
    }
}
