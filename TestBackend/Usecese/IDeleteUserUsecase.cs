namespace TestBackend.Usecases;
public interface IDeleteUserUsecase
{
    Task<string> ExcuteAsync(int id);
}
