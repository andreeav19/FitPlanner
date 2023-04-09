namespace FitPlannerAPI.Repositories.Base
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        public BaseRepository()
        {

        }

        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateAsyncGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
