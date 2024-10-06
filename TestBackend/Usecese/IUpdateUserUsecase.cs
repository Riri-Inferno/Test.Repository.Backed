using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface IUpdateUserUsecase
{
    Task<ReadUserResponse> ExcuteAsync(UpdateUserRequest request);
}
