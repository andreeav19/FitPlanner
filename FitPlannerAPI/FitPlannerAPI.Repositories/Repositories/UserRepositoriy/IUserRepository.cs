using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<Guid> GetIdByUsernameAsync(string username);
        public Task<bool> CreateUserMealAsync(UserMeal userMeal);
        public Task<bool> CreateUserWorkoutAsync(UserWorkout userWorkout);
        public Task<List<UserMeal>> GetMealsByUserIdAsync(Guid userId);
        public Task<List<UserWorkout>> GetWorkoutsByUserIdAsync(Guid userId);
        public Task<User> AuthenticateUserAsync(string username, string password);
        public Task<Role> GetUserRoleByIdAsync(Guid id);

    }
}
