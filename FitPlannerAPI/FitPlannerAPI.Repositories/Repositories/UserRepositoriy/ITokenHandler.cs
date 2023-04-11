using FitPlannerAPI.Models.Models;

namespace FitPlannerAPI.Repositories.Repositories.UserRepositoriy
{
    public interface ITokenHandler
    {
        Task<string> GetToken(User user);
    }
}
