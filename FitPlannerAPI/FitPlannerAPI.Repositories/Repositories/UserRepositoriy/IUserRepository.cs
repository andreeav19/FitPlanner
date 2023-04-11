using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<Guid> GetIdByUsername(string username);
        public Task<bool> CreateUserMeal(UserMeal userMeal);
        public Task<bool> CreateUserWorkout(UserWorkout userWorkout);
        public Task<List<UserMeal>> GetMealsByUserId(Guid userId);
        public Task<List<UserWorkout>> GetWorkoutsByUserId(Guid userId);
        public Task<User> AuthenticateUser(string username, string password);
        public Task<Role> GetUserRoleById(Guid id);

    }
}
