namespace TestBackend.Interactor.Dtos;

/// <summary>
/// ユーザー追加のリクエスト
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// ユーザー名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// メールアドレス
    /// </summary>
    public string Email { get; set; }
}
