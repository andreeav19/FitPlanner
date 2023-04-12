using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Users;
using FitPlannerAPI.DTO.Workouts;

namespace FitPlannerAPI.Services.Users
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(UserPost userPost);
        Task<bool> AddMealAsync(string username, UserMealPost userMealPost);
        Task<bool> AddWorkoutAsync(string username, UserWorkoutPost userWorkoutPost);
        Task<List<AssociatedMeal>> GetAssociatedMealsAsync(string username);
        Task<List<AssociatedWorkout>> GetAssociatedWorkoutsAsync(string username);
        Task<string> UserLoginAsync(UserLogin userLogin);
    }
}
