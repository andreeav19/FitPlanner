using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<bool> CreateUserMeal(UserMeal userMeal);
        public Task<bool> CreateUserWorkout(UserWorkout userWorkout);
        public Task<List<UserMeal>> GetMealByUserId(Guid userId);
        public Task<List<UserWorkout>> GetWorkoutByUserId(Guid userId);

    }
}
