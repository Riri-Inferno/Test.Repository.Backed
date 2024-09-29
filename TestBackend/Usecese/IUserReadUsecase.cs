using TestBackend.Interactor.Dtos;


namespace TestBackend.Usecases;
public interface IUserUsecase
{
    Task<UserReadResponse> ExecuteAsync(int id);
}
