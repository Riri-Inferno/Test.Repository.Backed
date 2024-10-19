using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestBackend.Interfaces
{
    public interface IGenericReadRepository<T> where T : class
    {
        /// <summary>
        /// 非同期的にすべてのエンティティのリストを取得
        /// </summary>
        /// <returns>すべてのエンティティを含むIEnumerable</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// クエリ可能なデータセットを返却
        /// </summary>
        /// <returns>IQueryable<T>型のクエリ可能なデータセット</returns>
        IQueryable<T> GetQueryableAsync();

        /// <summary>
        /// 指定されたIDに対応するエンティティを非同期的に取得
        /// </summary>
        /// <param name="id">取得するエンティティのID</param>
        /// <returns>指定されたIDに対応するエンティティ</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// 指定された条件に基づいてエンティティを非同期的に検索
        /// </summary>
        /// <param name="predicate">検索条件を定義するラムダ式</param>
        /// <returns>条件に一致するエンティティのリスト</returns>
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 指定された条件に基づいてクエリ可能なデータセットを返却
        /// </summary>
        /// <param name="predicate">フィルタリング条件を定義するラムダ式</param>
        /// <returns>条件に基づくIQueryable<T>。</returns>
        IQueryable<T> QueryByConditionAsync(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// 指定された条件に一致するエンティティが存在するかどうかを非同期的に確認
        /// </summary>
        /// <param name="predicate">存在確認する条件を定義するラムダ式</param>
        /// <returns>条件に一致するエンティティが存在すればtrue、それ以外はfalse</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}