using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface IUserReadUsecase
{
    Task<UserReadResponse> ExcuteAsync(int id);
}
