using TestBackend.Interactor.Dtos;
using TestBackend.Usecases;

namespace TestBackend.Controllers;

public class Query
{
    private readonly IUserReadUsecase _userReadUsecase;

    public Query
    (
        IUserReadUsecase userReadUsecase
    )
    {
        _userReadUsecase = userReadUsecase;
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
}
