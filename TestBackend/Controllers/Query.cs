using System.Runtime.CompilerServices;
using TestBackend.Interactor.Dtos;


namespace TestBackend.Controllers;

public class Query
{
    /// <summary>
    /// 動作確認用のクエリ
    /// </summary>
    /// <returns></returns>
    public string Hello() => "Hello, GraphQL!!";

    /// <summary>
    /// Userレコード取得クエリ
    /// </summary>
    /// <returns></returns>
    public async Task<UserReadResponse> ExcuteAsunc(int id)
    {

        // 仮のレスポンス
        return new UserReadResponse{
            Id = id,
            Name = "hoge",
            Email = "tekitou.com",
        };
    }
}
