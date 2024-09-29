namespace TestBackend.Interactor.Dtos;

public class UserReadResponse
{
    /// <summary>
    /// ユーザーID
    /// </summary>
    public int Id{get;set;}

    /// <summary>
    /// ユーザー名
    /// </summary>
    public string Name{get;set;}

    /// <summary>
    /// メールアドレス
    /// </summary>
    public string Email{get;set;}
}
