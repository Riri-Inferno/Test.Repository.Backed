using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface IUpsertUserUsecase
{
    Task<ReadUserResponse> ExcuteAsync(UpdateUserRequest request);
}
