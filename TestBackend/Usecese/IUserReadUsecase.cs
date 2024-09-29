using TestBackend.Interactor.Dtos;


namespace TestBackend.Usecases;
public interface IUserUsecase
{
    Task<UserReadResponse> ExcuteAsync(int id);
}
