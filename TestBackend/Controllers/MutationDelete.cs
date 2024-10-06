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
    /// <param name="id">ユーザーID</param>
    /// <param name="deleteUserUsecase">ユーザー削除ユースケース</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<bool> DeleteUserAsync
    (
        int id,
        [Service]IDeleteUserUsecase deleteUserUsecase
    )=>await deleteUserUsecase.ExcuteAsync(id);
}
