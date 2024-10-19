using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<T> GetQueryableAsync()
        {
            return _dbSet;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // 修正：Func<T, bool> から Expression<Func<T, bool>> に変更
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public IQueryable<T> QueryByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        // 存在確認用の ExistsAsync メソッドを追加
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
    }
}