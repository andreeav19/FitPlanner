using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public async Task<bool> CreateUserMeal(UserMeal userMeal)
        {
            await _context.UserMeals.AddAsync(userMeal);
            var entries = await _context.SaveChangesAsync();

            if (entries == 0) { return false; }

            return true;
        }

        public async Task<bool> CreateUserWorkout(UserWorkout userWorkout)
        {
            await _context.UserWorkouts.AddAsync(userWorkout);
            var entries = await _context.SaveChangesAsync();

            if (entries == 0) { return false; }

            return true;

        }

        public async Task<List<UserMeal>> GetMealByUserId(Guid userId)
        {
            var meals = await _context.UserMeals
                .Where(um => um.UserId == userId)
                .Include(um => um.Meal)
                .ToListAsync();

            return meals;
        }

        public async Task<List<UserWorkout>> GetWorkoutByUserId(Guid userId)
        {
            var workouts = await _context.UserWorkouts
                .Where(uw => uw.UserId == userId)
                .Include(um => um.WorkoutRoutine)
                .ToListAsync();

            return workouts;
        }
    }
}
