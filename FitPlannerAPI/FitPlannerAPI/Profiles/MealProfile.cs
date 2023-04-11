using AutoMapper;

namespace FitPlannerAPI.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<FitPlannerAPI.Models.Models.Meal, FitPlannerAPI.DTO.Meals.Meal>().ReverseMap();
            CreateMap<FitPlannerAPI.Models.Models.MealIngredient, FitPlannerAPI.DTO.Workouts.WorkoutExercisePost>().ReverseMap();
        }
    }
}
