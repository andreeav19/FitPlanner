using FitPlannerAPI.DTO.Base;

namespace FitPlannerAPI.DTO.Exercises
{
    public class Exercise : BaseDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
    }
}
