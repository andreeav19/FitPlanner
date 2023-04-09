using AutoMapper;
using FitPlannerAPI.DTO.Exercises;
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

        public Task<ObjectResult> CreateExercise()
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> DeleteExercise()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExerciseGet>> GetAllExercises()
        {
            var exercises = await _exerciseRepository.GetAllAsList();
            var exercisesDTO = _mapper.Map<List<ExerciseGet>>(exercises);

            return exercisesDTO;
        }

        public Task<ObjectResult> GetExerciseById()
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> UpdateExercise()
        {
            throw new NotImplementedException();
        }
    }
}
