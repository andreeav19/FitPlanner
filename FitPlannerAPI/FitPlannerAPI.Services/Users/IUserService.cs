using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Users;
using FitPlannerAPI.DTO.Workouts;

namespace FitPlannerAPI.Services.Users
{
    public interface IUserService
    {
        Task<Guid> CreateUser(UserPost userPost);
        Task<bool> AddMeal(string username, UserMealPost userMealPost);
        Task<bool> AddWorkout(string username, UserWorkoutPost userWorkoutPost);
        Task<List<AssociatedMeal>> GetAssociatedMeals(string username);
        Task<List<AssociatedWorkout>> GetAssociatedWorkouts(string username);
        Task<string> UserLogin(UserLogin userLogin);
    }
}
