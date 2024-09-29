using System.Runtime.CompilerServices;
using TestBackend.Interactor.Dtos;
using Microsoft.AspNetCore.Mvc;
using TestBackend.Usecases;


namespace TestBackend.Controllers;

public class Query: ControllerBase
{
    private readonly IUserUsecase _userReadUsecase;

    public Query(IUserUsecase userReadUsecase)
    {
        _userReadUsecase = userReadUsecase;
    }
    
    /// <summary>
    /// 動作確認用のクエリ
    /// </summary>
    /// <returns></returns>
    public string Hello() => "Hello, GraphQL!!";

    /// <summary>
    /// Userレコード取得クエリ
    /// </summary>
    /// <returns></returns>
    public async Task<UserReadResponse> GetUserReadAsync(int id)
    {
        var response = await _userReadUsecase.hoge(id);

        return response; // レスポンスを返す
    }
}
