using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;
using System.Data;
using System.Transactions;

namespace TestBackend.Interactor;

public class DeleteUserInteractor : IDeleteUserUsecase
{
    private readonly IGenericReadRepository<User> _readUserRepository;
    private readonly IGenericWriteRepository<User> _writeUserRepository;
    private readonly IMapper _mapper;

    public DeleteUserInteractor(
        IGenericReadRepository<User> readUserRepository,
        IGenericWriteRepository<User> writeUserRepository,
        IMapper mapper
    )
    {
        _readUserRepository = readUserRepository;
        _writeUserRepository = writeUserRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// ユーザー削除
    /// </summary>
    /// <param name="id">ユーザーID</param>
    /// <returns>削除したユーザーレコード</returns>
    public async Task<bool> ExcuteAsync(int id)
    {
        using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable },
                TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                
                await _writeUserRepository.DeleteAsync(id);
                await _writeUserRepository.SaveChangesAsync();
                // トランザクションをコミット
                scope.Complete();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ユーザーの削除中にエラーが発生しました。");
                throw new Exception("ユーザーの削除中にエラーが発生しました。", ex);
            }
        }
    }
}
