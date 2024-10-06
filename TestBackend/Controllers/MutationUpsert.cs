using TestBackend.Interactor.Dtos;
using TestBackend.Usecases;

namespace TestBackend.Controllers;

public partial class Mutation
{
    /// <summary>
    /// ユーザー情報更新追加
    /// </summary>
    /// <param name="request">ユーザー更新追加リクエスト</param>
    /// <param name="createUserUsecase">ユーザー更新追加ユースケース</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<ReadUserResponse> UpsertUserAsync
    (
        UpdateUserRequest request,
        [Service]IUpsertUserUsecase updateUserUsecase
    )
    {
        var response = await updateUserUsecase.ExcuteAsync(request);
        return response;
    }
}