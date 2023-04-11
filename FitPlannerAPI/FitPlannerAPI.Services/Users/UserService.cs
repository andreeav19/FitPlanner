using AutoMapper;
using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Users;
using FitPlannerAPI.DTO.Workouts;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.UserRepositoriy;

namespace FitPlannerAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<bool> AddMeal(string username, UserMealPost userMealPost)
        {
            var userId = await _userRepository.GetIdByUsername(username);

            var userMeal = new UserMeal
            {
                UserId = userId,
                MealId = userMealPost.MealId
            };

            return await _userRepository.CreateUserMeal(userMeal);

        }

        public async Task<bool> AddWorkout(string username, UserWorkoutPost userWorkoutPost)
        {
            var userId = await _userRepository.GetIdByUsername(username);

            var userWorkout = new UserWorkout
            {
                UserId = userId,
                WorkoutRoutineId = userWorkoutPost.WorkoutId
            };

            return await _userRepository.CreateUserWorkout(userWorkout);
            
        }

        public async Task<Guid> CreateUser(UserPost userPost)
        {
            // id corresponding to 'guest' role
            var stringGuid = "81a130d2-502f-4cf1-a376-63edeb000e9f";

            var user = new FitPlannerAPI.Models.Models.User
            {
                Username = userPost.Username,
                FirstName = userPost.FirstName,
                LastName = userPost.LastName,
                Email = userPost.Email,
                Password = userPost.Password,
                RoleId = Guid.Parse(stringGuid)
            };

            var createdUserId = await _userRepository.CreateAsyncGetId(user);

            return createdUserId;
        }

        public async Task<List<AssociatedMeal>> GetAssociatedMeals(string username)
        {
            var userId = await _userRepository.GetIdByUsername(username);
            var associatedMeals = await _userRepository.GetMealsByUserId(userId);

            List<AssociatedMeal> mealsList = new List<AssociatedMeal>();

            foreach (var meal in associatedMeals)
            {
                mealsList.Add(new AssociatedMeal
                {
                    Id = meal.MealId,
                    Name = meal.Meal.Name,
                    CreatedDate = meal.Meal.CreatedDate,
                    UpdatedDate = meal.Meal.UpdatedDate,
                });
            }

            return mealsList;
        }

        public async Task<List<AssociatedWorkout>> GetAssociatedWorkouts(string username)
        {
            var userId = await _userRepository.GetIdByUsername(username);
            var associatedWorkouts = await _userRepository.GetWorkoutsByUserId(userId);

            List<AssociatedWorkout> workoutsList = new List<AssociatedWorkout>();

            foreach (var workout in associatedWorkouts)
            {
                workoutsList.Add(new AssociatedWorkout
                {
                    Id = workout.WorkoutRoutineId,
                    Name = workout.WorkoutRoutine.Name,
                    Description = workout.WorkoutRoutine.Description,
                    Breaktime = workout.WorkoutRoutine.Breaktime,
                    CreatedDate = workout.WorkoutRoutine.CreatedDate,
                    UpdatedDate = workout.WorkoutRoutine.UpdatedDate,
                });
            }

            return workoutsList;
        }
    }
}
