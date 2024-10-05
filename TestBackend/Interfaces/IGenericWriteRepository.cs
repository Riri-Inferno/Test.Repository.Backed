using System.Threading.Tasks;

namespace TestBackend.Interfaces
{
    public interface IGenericWriteRepository<T> where T : class
    {
        Task AddAsync(T entity); // 新規追加
        Task UpdateAsync(T entity); // 更新
        Task DeleteAsync(int id); // 削除
        Task SaveChangesAsync(); // 変更を保存
    }
}
