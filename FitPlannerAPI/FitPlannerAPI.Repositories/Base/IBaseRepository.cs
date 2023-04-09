namespace FitPlannerAPI.Repositories.Base
{
    internal interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllAsQueryable();

        Task CreateAsync(TEntity entity);
        Task<Guid> CreateAsyncGetId(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);

        Task<int> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);

    }
}
