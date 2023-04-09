using FitPlannerApi.Models;
using FitPlannerAPI.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FitPlannerAPI.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly FitPlannerDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public BaseRepository(FitPlannerDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> CreateAsyncGetId(TEntity entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _table.Update(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsList()
        {
           return await _table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _table.AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _table.FindAsync(id);
        }
    }
}
