namespace FitPlannerAPI.Repositories.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsListAsync();
        IQueryable<TEntity> GetAllAsQueryable();

        Task CreateAsync(TEntity entity);
        Task<Guid> CreateAsyncGetId(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

    }
}
