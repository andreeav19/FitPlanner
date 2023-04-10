using AutoMapper;
using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.ExerciseRepository;
using Microsoft.AspNetCore.Mvc;

namespace FitPlannerAPI.Services.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            this._exerciseRepository = exerciseRepository;
            this._mapper = mapper;
        }

        public Task<Guid> CreateExercise(ExercisePost exercisePost)
        {
            var exercise = new FitPlannerAPI.Models.Models.Exercise
            {
                Name = exercisePost.Name,
                Description = exercisePost.Description,
                Duration = exercisePost.Duration != 0 ? exercisePost.Duration : null
            };

            var createdExerciseId = _exerciseRepository.CreateAsyncGetId(exercise);

            return createdExerciseId;
        }

        public Task<ObjectResult> DeleteExercise()
        {
            throw new NotImplementedException();
        }

        public async Task<List<FitPlannerAPI.DTO.Exercises.Exercise>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllAsList();
            var exercisesDTO = _mapper.Map<List<FitPlannerAPI.DTO.Exercises.Exercise>>(exercises);

            return exercisesDTO;
        }

        public async Task<FitPlannerAPI.DTO.Exercises.Exercise> GetExerciseById(Guid id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            var exerciseDTO = _mapper.Map<FitPlannerAPI.DTO.Exercises.Exercise>(exercise);

            return exerciseDTO;
        }

        public async Task<FitPlannerAPI.DTO.Exercises.Exercise> UpdateExercise(Guid id, ExercisePut exercisePut)
        {
            var exercise = new FitPlannerAPI.Models.Models.Exercise
            {
                Name = exercisePut.Name,
                Description = exercisePut.Description,
                Duration = exercisePut.Duration != 0 ? exercisePut.Duration : null
            };

            exercise = await _exerciseRepository.UpdateAsync(exercise);

            if (exercise == null)
            {
                return null;
            }

            var exerciseDTO = _mapper.Map<FitPlannerAPI.DTO.Exercises.Exercise>(exercise);

            return exerciseDTO;
        }
    }
}
