namespace FitPlannerAPI.DTO.Base
{
    public class BaseDTO : IBaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
