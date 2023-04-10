using FitPlannerAPI.DTO.Base;

namespace FitPlannerAPI.DTO.Ingredients
{
    public class Ingredient : BaseDTO
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
