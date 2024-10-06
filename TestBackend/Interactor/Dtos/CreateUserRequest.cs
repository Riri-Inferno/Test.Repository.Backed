namespace TestBackend.Interactor.Dtos;

/// <summary>
/// ユーザー追加のリクエスト
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// ユーザー名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    public string UserEmail { get; set; }
}
