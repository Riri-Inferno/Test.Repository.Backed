// GenericReadRepository.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestBackend.Interfaces;
using TestBackend.Data;

namespace TestBackend.Repositories
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericReadRepository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.FromResult(_dbSet.AsEnumerable().Where(predicate));
        }
    }
}
