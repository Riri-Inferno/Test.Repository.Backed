using TestBackend.Interactor.Dtos;

namespace TestBackend.Usecases;
public interface IReadUserListUsecase
{
    Task<List<ReadUserResponse>> ExcuteAsync();
}
