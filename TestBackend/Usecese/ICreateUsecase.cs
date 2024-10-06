using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface ICreateUserUsecase
{
    Task<ReadUserResponse> ExcuteAsync(CreateUserRequest request);
}
