namespace FitPlannerAPI.DTO.Base
{
    public interface IBaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
