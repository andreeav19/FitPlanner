using FitPlannerAPI.Models.Models;

namespace FitPlannerAPI.Repositories.Repositories.TokenHandler
{
    public interface ITokenHandler
    {
        Task<string> GetTokenAsync(User user);
    }
}
