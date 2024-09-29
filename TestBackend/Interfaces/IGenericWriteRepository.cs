using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestBackend.Interfaces
{
    public interface IGenericReadRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); // 全件取得
        Task<T> GetByIdAsync(int id); // IDによる取得
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate); // 条件による取得
    }
}
