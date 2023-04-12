using AutoMapper;
using FitPlannerAPI.DTO.Meals;
using FitPlannerAPI.DTO.Users;
using FitPlannerAPI.DTO.Workouts;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Repositories.TokenHandler;
using FitPlannerAPI.Repositories.Repositories.UserRepositoriy;

namespace FitPlannerAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public UserService(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this._userRepository = userRepository;
            this._tokenHandler = tokenHandler;
        }

        public async Task<bool> AddMealAsync(string username, UserMealPost userMealPost)
        {
            var userId = await _userRepository.GetIdByUsernameAsync(username);

            var userMeal = new UserMeal
            {
                UserId = userId,
                MealId = userMealPost.MealId
            };

            return await _userRepository.CreateUserMealAsync(userMeal);

        }

        public async Task<bool> AddWorkoutAsync(string username, UserWorkoutPost userWorkoutPost)
        {
            var userId = await _userRepository.GetIdByUsernameAsync(username);

            var userWorkout = new UserWorkout
            {
                UserId = userId,
                WorkoutRoutineId = userWorkoutPost.WorkoutId
            };

            return await _userRepository.CreateUserWorkoutAsync(userWorkout);
            
        }

        public async Task<Guid> CreateUserAsync(UserPost userPost)
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

        public async Task<List<AssociatedMeal>> GetAssociatedMealsAsync(string username)
        {
            var userId = await _userRepository.GetIdByUsernameAsync(username);
            var associatedMeals = await _userRepository.GetMealsByUserIdAsync(userId);

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

        public async Task<List<AssociatedWorkout>> GetAssociatedWorkoutsAsync(string username)
        {
            var userId = await _userRepository.GetIdByUsernameAsync(username);
            var associatedWorkouts = await _userRepository.GetWorkoutsByUserIdAsync(userId);

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

        public async Task<string> UserLoginAsync(UserLogin userLogin)
        {
            var user = await _userRepository.AuthenticateUserAsync(userLogin.Username, userLogin.Password);

            if (user == null) 
            {
                return null;
            }

            var token = await _tokenHandler.GetTokenAsync(user);

            return token;
        }
    }
}
