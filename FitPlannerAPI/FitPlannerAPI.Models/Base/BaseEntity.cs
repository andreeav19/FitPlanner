using System.ComponentModel.DataAnnotations;

namespace FitPlannerAPI.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
