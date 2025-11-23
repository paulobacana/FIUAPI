using FIUAPI.Data;
using FIUAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FIUAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ConnectionContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}