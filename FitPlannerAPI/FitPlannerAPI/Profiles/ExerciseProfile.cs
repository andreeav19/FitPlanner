﻿using AutoMapper;

namespace FitPlannerAPI.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile() { 
            CreateMap<FitPlannerAPI.Models.Models.Exercise, FitPlannerAPI.DTO.Exercises.Exercise>().ReverseMap();
        }
    }
}
