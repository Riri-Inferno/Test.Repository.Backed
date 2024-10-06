using Microsoft.AspNetCore.Http.HttpResults;
using TestBackend.Interactor.Dtos;
using TestBackend.Usecases;
using Microsoft.AspNetCore.Mvc;

namespace TestBackend.Controllers;

public partial class Mutation
{
    /// <summary>
    /// ユーザー作成
    /// </summary>
    /// <param name="request">ユーザー作成リクエスト</param>
    /// <param name="createUserUsecase">ユーザー作成ユースケース</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<ReadUserResponse> CreateUserAsync
    (
        CreateUserRequest request,
        [Service]ICreateUserUsecase createUserUsecase
    )
    {
        var response = await createUserUsecase.ExcuteAsync(request);
        return response;
    }
}