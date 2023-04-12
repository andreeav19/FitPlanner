using AutoMapper;
using FitPlannerAPI.DTO.Exercises;
using FitPlannerAPI.DTO.Workouts;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.WorkoutRepository;

namespace FitPlannerAPI.Services.Workouts
{
    public class WorkoutRoutineService : IWorkoutRoutineService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public WorkoutRoutineService(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            this._workoutRepository = workoutRepository;
            this._mapper = mapper;
        }

        public async Task<bool> AddExerciseAsync(Guid workoutId, WorkoutExercisePost workoutExercisePost)
        {
            var workoutExercise = new WorkoutExercise
            {
                WorkoutRoutineId = workoutId,
                ExerciseId = workoutExercisePost.ExerciseId,
                ExerciseCount = workoutExercisePost.ExerciseCount,
            };

            return await _workoutRepository.CreateWorkoutExerciseAsync(workoutExercise);
        }

        public async Task<Guid> CreateWorkoutRoutineAsync(WorkoutRoutinePost workoutRoutinePost)
        {
            var workout = new FitPlannerAPI.Models.Models.WorkoutRoutine
            {
                Name = workoutRoutinePost.Name,
                Description = workoutRoutinePost.Description,
                Breaktime = workoutRoutinePost.Breaktime != 0 ? workoutRoutinePost.Breaktime : null,
            };

            var createdWorkoutId = await _workoutRepository.CreateAsyncGetId(workout);

            return createdWorkoutId;
        }

        public async Task<bool> DeleteWorkoutRoutineAsync(Guid id)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);

            if (workout == null)
            {
                return false;
            }

            await _workoutRepository.DeleteAsync(workout);

            return true;
        }

        public async Task<List<FitPlannerAPI.DTO.Workouts.WorkoutRoutine>> GetAllWorkoutRoutinesAsync()
        {
            var workouts = await _workoutRepository.GetAllAsListAsync();
            var workoutsDTO = _mapper.Map<List<FitPlannerAPI.DTO.Workouts.WorkoutRoutine>>(workouts);

            return workoutsDTO;
        }

        public async Task<List<DTO.Exercises.AssociatedExercise>> GetExercisesAsync(Guid workoutId)
        {
            var associatedExercises = await _workoutRepository.GetExerciseByWorkoutIdAsync(workoutId);
            List<AssociatedExercise> exercisesList = new List<AssociatedExercise>();
            foreach (var e in associatedExercises)
            {
                exercisesList.Add(new AssociatedExercise
                {
                    Id = e.ExerciseId,
                    Name = e.Exercise.Name,
                    Duration = e.Exercise.Duration,
                    Description = e.Exercise.Description,
                    CreatedDate = e.Exercise.CreatedDate,
                    UpdatedDate = e.Exercise.UpdatedDate,
                    Count = e.ExerciseCount
                });
            }

            return exercisesList;

        }

        public async Task<FitPlannerAPI.DTO.Workouts.WorkoutRoutine> GetWorkoutRoutineByIdAsync(Guid id)
        {
            var workout = await _workoutRepository.GetByIdAsync(id);
            var workoutDTO = _mapper.Map<FitPlannerAPI.DTO.Workouts.WorkoutRoutine>(workout);

            return workoutDTO;
        }

        public async Task<FitPlannerAPI.DTO.Workouts.WorkoutRoutine> UpdateWorkoutRoutineAsync(Guid id, WorkoutRoutinePut workoutRoutinePut)
        {
            var workout = new FitPlannerAPI.Models.Models.WorkoutRoutine 
            { 
                Name = workoutRoutinePut.Name,
                Description = workoutRoutinePut.Description,
                Breaktime = workoutRoutinePut.Breaktime != 0 ? workoutRoutinePut.Breaktime : null
            };

            workout = await _workoutRepository.UpdateAsync(id, workout);

            if (workout == null)
            {
                return null;
            }

            var workoutDTO = _mapper.Map<FitPlannerAPI.DTO.Workouts.WorkoutRoutine>(workout);

            return workoutDTO;
        }
    }
}
