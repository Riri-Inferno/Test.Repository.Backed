namespace TestBackend.Interactor.Dtos;

public class UpdateUserRequest
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public int Id{get;set;}

    /// <summary>
    /// ユーザー名
    /// </summary>
    public string UserName{get;set;}

    /// <summary>
    /// メールアドレス
    /// </summary>
    public string UserEmail{get;set;}
}
