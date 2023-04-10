using FitPlannerApi.Models;
using FitPlannerAPI.Models.Models;
using FitPlannerAPI.Repositories.Base;

namespace FitPlannerAPI.Repositories.Repositories.WorkoutRepository
{
    public class WorkoutRepository : BaseRepository<WorkoutRoutine>, IWorkoutRepository
    {
        public WorkoutRepository(FitPlannerDbContext context) : base(context)
        {
        }
    }
}
