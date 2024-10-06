namespace TestBackend.Usecases;
public interface IDeleteUserUsecase
{
    Task<bool> ExcuteAsync(int id);
}
