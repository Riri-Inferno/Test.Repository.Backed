using System.Threading.Tasks;

namespace TestBackend.Interfaces
{
    public interface IGenericWriteRepository<T> where T : class
    {
        Task AddAsync(T entity); // 新規追加
        Task<T> UpdateAsync(T entity); // 更新
        Task DeleteAsync(int id); // 削除
        // ToDo: 現在はIDでのみ検索できるが将来的に可変にしたい
        Task<T> UpsertAsync(T entity, int id); // 更新追加
        Task SaveChangesAsync(); // 変更を保存
    }
}
