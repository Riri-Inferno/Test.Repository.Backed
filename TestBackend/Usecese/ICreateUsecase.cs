using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface ICreateUserUsecase
{
    Task ExcuteAsync(CreateUserRequest request);
}
