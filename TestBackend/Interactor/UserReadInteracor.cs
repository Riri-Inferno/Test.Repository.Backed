using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;

public class UserReadInteractor : IUserUsecase
{
    private readonly IGenericReadRepository<User> _userRepository;

    public UserReadInteractor(IGenericReadRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Userレコード取得クエリ
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserReadResponse> hoge(int id)
    {
        // データベースからユーザーを取得するロジック
        var user = await _userRepository.GetByIdAsync(id);


        Console.WriteLine("ooaoaoaoaoaooaoaoooaooooaooaooaooa");
        Console.WriteLine(user);
        
        // ユーザーが見つからない場合はnullを返す
        if (user == null)
        {
            return null; // または適切なエラーハンドリングを行う
        }

        // レスポンスを生成
        return new UserReadResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}
