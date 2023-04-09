using FitPlannerAPI.DTO.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Services.Exercises
{
    public interface IExerciseService
    {
        Task<List<ExerciseGet>> GetAllExercises();
        Task<ObjectResult> GetExerciseById();
        Task<ObjectResult> CreateExercise();
        Task<ObjectResult> UpdateExercise();
        Task<ObjectResult> DeleteExercise();
    }
}
