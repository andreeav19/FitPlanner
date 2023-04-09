using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.ExerciseRepository
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(FitPlannerDbContext context) : base(context) { }
    }
}
