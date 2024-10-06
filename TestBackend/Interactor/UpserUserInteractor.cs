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
                var mappedRequest = _mapper.Map<User>(request);
                // ユーザー名またはメールアドレスが既に存在するか確認
                var users = await _readUserRepository
                    .FindAsync(e => e.UserName == request.UserName || e.UserEmail == request.UserEmail);

                var existingUser = users.FirstOrDefault();

                // ユーザーが存在するときに更新
                if (existingUser != null)
                {
                    // 更新用エンティティ
                    var user = _mapper.Map(request, existingUser);

                    var response = await _writeUserRepository.UpdateAsync(user);
                    await _writeUserRepository.SaveChangesAsync();

                    scope.Complete();
                    
                    return  _mapper.Map<ReadUserResponse>(response);
                }
                // ユーザーが存在しなかったら追加
                else
                {
                    await _writeUserRepository.AddAsync(mappedRequest);
                    await _writeUserRepository.SaveChangesAsync();

                    // 作成されたユーザーのレスポンスを返す
                    var response = _mapper.Map<ReadUserResponse>(mappedRequest);

                    // トランザクションをコミット
                    scope.Complete();
                    
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ユーザーのUpsert処理中ににエラーが発生しました。");
                throw new Exception("ユーザーのUpsert処理中にエラーが発生しました。", ex);
            }
        }
    }
}
