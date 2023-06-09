﻿using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerAPI.Repositories.Repositories.WorkoutRepository
{
    public class WorkoutRepository : BaseRepository<WorkoutRoutine>, IWorkoutRepository
    {
        public WorkoutRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public async Task<WorkoutRoutine> UpdateAsync(Guid id, WorkoutRoutine workoutRoutine)
        {
            var existingWorkout = await GetByIdAsync(id);

            if (existingWorkout == null)
            {
                return null;
            }

            existingWorkout.Name = workoutRoutine.Name;
            existingWorkout.Description = workoutRoutine.Description;
            existingWorkout.Breaktime = workoutRoutine.Breaktime;

            await _context.SaveChangesAsync();

            return existingWorkout;
        }
        public async Task<bool> CreateWorkoutExerciseAsync(WorkoutExercise workoutExercise)
        {
            await _context.WorkoutExercises.AddAsync(workoutExercise);
            var entries = await _context.SaveChangesAsync();

            if (entries == 0) { return false; }

            return true;
        }

        public async Task<List<FitPlannerAPI.Models.Models.WorkoutExercise>> GetExerciseByWorkoutIdAsync(Guid workoutId)
        {
            var exercises = await _context.WorkoutExercises
                .Where(we => we.WorkoutRoutineId == workoutId)
                .Include(we => we.Exercise)
                .ToListAsync();

            return exercises;
        }
    }
}
