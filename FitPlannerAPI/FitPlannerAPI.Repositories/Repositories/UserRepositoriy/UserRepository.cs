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

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var user = await _table.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return null;
            }

            user.Password = password;

            return user;
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

        public async Task<Guid> GetIdByUsername(string username)
        {
            var user = await _table.Where(u => u.Username == username).FirstOrDefaultAsync();

            return user.Id;
        }

        public async Task<List<UserMeal>> GetMealsByUserId(Guid userId)
        {
            var meals = await _context.UserMeals
                .Where(um => um.UserId == userId)
                .Include(um => um.Meal)
                .ToListAsync();

            return meals;
        }

        public async Task<List<UserWorkout>> GetWorkoutsByUserId(Guid userId)
        {
            var workouts = await _context.UserWorkouts
                .Where(uw => uw.UserId == userId)
                .Include(um => um.WorkoutRoutine)
                .ToListAsync();

            return workouts;
        }

        public async Task<Role> GetUserRoleById(Guid id)
        {
            var role = await _table
                .Where(u => u.Id == id)
                .Include(um => um.Role)
                .Select(result => result.Role)
                .FirstOrDefaultAsync();

            return role;
        }
    }
}
