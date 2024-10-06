using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface IUserReadUsecase
{
    Task<ReadUserResponse> ExcuteAsync(int id);
}
