using AutoMapper;

namespace FitPlannerAPI.Profiles
{
    public class WorkoutRoutineProfile  : Profile
    {
        public WorkoutRoutineProfile()
        {
            CreateMap<FitPlannerAPI.Models.Models.WorkoutRoutine, FitPlannerAPI.DTO.Workouts.WorkoutRoutine>().ReverseMap();
            CreateMap<FitPlannerAPI.Models.Models.WorkoutExercise, FitPlannerAPI.DTO.Workouts.WorkoutExercisePost>().ReverseMap();
        }
    }
}
