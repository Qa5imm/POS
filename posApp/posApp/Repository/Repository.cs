
using Microsoft.EntityFrameworkCore;
using posApp.DB;

namespace posApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(e => EF.Property<int>(e, "id") == id);

        }
        public async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityId = _context.Entry(entity).Property("id").CurrentValue;

            var existingEntity = await _dbSet.AsNoTracking().SingleOrDefaultAsync(e => EF.Property<int>(e, "id") == (int)entityId);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
