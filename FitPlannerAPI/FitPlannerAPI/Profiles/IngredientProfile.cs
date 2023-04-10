using AutoMapper;

namespace FitPlannerAPI.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<FitPlannerAPI.Models.Models.Ingredient, FitPlannerAPI.DTO.Ingredients.Ingredient>().ReverseMap();
        }
    }
}
