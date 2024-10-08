using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestBackend.Interfaces;
using TestBackend.Data;

namespace TestBackend.Repositories
{
    public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericWriteRepository(MyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
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

        public async Task<T> UpsertAsync(T entity, int id)
        {
            var existingEntity = await _dbSet.FindAsync(id);

            if (existingEntity == null)
            {
                await _dbSet.AddAsync(entity);
            }
            else
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
