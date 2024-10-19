using TestBackend.Interactor.Dtos;
using TestBackend.Usecases;

namespace TestBackend.Controllers;

public class Query
{
    private readonly IUserReadUsecase _userReadUsecase;
    private readonly IReadUserListUsecase _readUserListUsecase;

    public Query
    (
        IUserReadUsecase userReadUsecase,
        IReadUserListUsecase readUserListUsecase
    )
    {
        _userReadUsecase = userReadUsecase;
        _readUserListUsecase = readUserListUsecase;
    }

    /// <summary>
    /// Userレコード取得クエリ
    /// <param name="id">ユーザーID</param>
    /// <param name="userReadUsecase">ユーザー情報取得ユースケース</param>
    /// <returns>取得したユーザーレコード</returns>
    public async Task<ReadUserResponse> GetUserAsync
    (
        int id,
        [Service]IUserReadUsecase userReadUsecase
    )
    {
        var response = await userReadUsecase.ExcuteAsync(id);
        return response;
    }

    /// <summary>
    /// User一覧取得クエリ
    /// <param name="id">ユーザーID</param>
    /// <param name="readUserListUsecase">User一覧取得ユースケース</param>
    /// <returns>取得したユーザーレコード</returns>
    public async Task<List<ReadUserResponse>> GetUserListAsync
    (
        [Service]IReadUserListUsecase readUserListUsecase
    )
    {
        var response = await readUserListUsecase.ExcuteAsync();
        return response;
    }
}
