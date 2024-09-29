using TestBackend.Interactor.Dtos;


namespace TestBackend.Usecases;
public interface IUserUsecase
{
    Task<UserReadResponse> hoge(int id);
}
