using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;
using System.Data;
using System.Transactions;

namespace TestBackend.Interactor;

public class UpsertUserInteractor : IUpsertUserUsecase
{
    private readonly IGenericReadRepository<User> _readUserRepository;
    private readonly IGenericWriteRepository<User> _writeUserRepository;
    private readonly IMapper _mapper;

    public UpsertUserInteractor(
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
    /// ユーザー更新
    /// </summary>
    /// <param name="request">ユーザー更新リクエスト</param>
    /// <returns>更新したユーザーレコード</returns>
    public async Task<ReadUserResponse> ExcuteAsync(UpdateUserRequest request)
    {
        using (var scope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable },
                TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {

                var existingUser = await _readUserRepository.GetByIdAsync(request.Id);

                var user = _mapper.Map(request, existingUser);

                var response = await _writeUserRepository.UpsertAsync(user,request.Id);

                await _writeUserRepository.SaveChangesAsync();

                scope.Complete();
                
                return  _mapper.Map<ReadUserResponse>(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ユーザーの更新中にエラーが発生しました。");
                throw new Exception("ユーザーの更新中にエラーが発生しました。", ex);
            }
        }
    }
}
