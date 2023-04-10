using FitPlannerAPI.DTO.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPlannerAPI.Services.Workouts
{
    internal class WorkoutRoutineService : IWorkoutRoutineService
    {
        public Task<Guid> CreateWorkoutRoutine(WorkoutRoutinePost workoutRoutinePost)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteWorkoutRoutine(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkoutRoutine>> GetAllWorkoutRoutine()
        {
            throw new NotImplementedException();
        }

        public Task<WorkoutRoutine> GetWorkoutRoutineById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkoutRoutine> UpdateWorkoutRoutine(Guid id, WorkoutRoutinePut workoutRoutinePut)
        {
            throw new NotImplementedException();
        }
    }
}
