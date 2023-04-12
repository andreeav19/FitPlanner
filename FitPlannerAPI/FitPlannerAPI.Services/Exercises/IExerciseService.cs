using FitPlannerAPI.DTO.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Services.Exercises
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(Guid id);
        Task<Guid> CreateExerciseAsync(ExercisePost exercisePost);
        Task<Exercise> UpdateExerciseAsync(Guid id, ExercisePut exercisePut);
        Task<bool> DeleteExerciseAsync(Guid id);
    }
}
