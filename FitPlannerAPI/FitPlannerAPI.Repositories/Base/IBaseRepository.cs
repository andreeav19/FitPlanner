namespace FitPlannerAPI.Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsList();
        IQueryable<TEntity> GetAllAsQueryable();

        Task CreateAsync(TEntity entity);
        Task<Guid> CreateAsyncGetId(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

    }
}
