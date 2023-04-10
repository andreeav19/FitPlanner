using FitPlannerAPI.DTO.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Services.Exercises
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercises();
        Task<Exercise> GetExerciseById(Guid id);
        Task<Guid> CreateExercise(ExercisePost exercisePost);
        Task<ObjectResult> UpdateExercise();
        Task<ObjectResult> DeleteExercise();
    }
}
