using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FitPlannerDbContext context) : base(context)
        {
        }

        public Task<bool> CreateUserMeal(UserMeal userMeal)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUserWorkout(UserWorkout userWorkout)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserMeal>> GetMealByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserWorkout>> GetWorkoutByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
