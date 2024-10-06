using TestBackend.Interactor.Dtos;
using TestBackend.Usecases;

namespace TestBackend.Controllers;

public partial class Mutation
{
    /// <summary>
    /// ユーザー情報更新
    /// </summary>
    /// <param name="request">ユーザー更新リクエスト</param>
    /// <param name="createUserUsecase">ユーザー更新ユースケース</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<ReadUserResponse> UpdateUserAsync
    (
        UpdateUserRequest request,
        [Service]IUpdateUserUsecase updateUserUsecase
    )
    {
        var response = await updateUserUsecase.ExcuteAsync(request);
        return response;
    }
}