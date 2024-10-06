using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;
using System.Data;
using System.Transactions;

namespace TestBackend.Interactor;

public class CreateUserInteractor : ICreateUserUsecase
{
    private readonly IGenericReadRepository<User> _readUserRepository;
    private readonly IGenericWriteRepository<User> _writeUserRepository;
    private readonly IMapper _mapper;

    public CreateUserInteractor(
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
    /// ユーザー作成
    /// </summary>
    /// <param name="request">ユーザー作成リクエスト</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<ReadUserResponse> ExcuteAsync(CreateUserRequest request)
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

                if (existingUser != null)
                {
                    if (existingUser.UserName == request.UserName && existingUser.UserEmail == request.UserEmail)
                    {
                        throw new DuplicateNameException("このユーザー名とEmailアドレスはすでに登録されています");
                    }
                    else if (existingUser.UserName == request.UserName)
                    {
                        throw new DuplicateNameException("このユーザー名はすでに登録されています");
                    }
                    else if (existingUser.UserEmail == request.UserEmail)
                    {
                        throw new DuplicateNameException("このEmailアドレスはすでに登録されています");
                    }
                }

                await _writeUserRepository.AddAsync(mappedRequest);
                await _writeUserRepository.SaveChangesAsync();

                // 作成されたユーザーのレスポンスを返す
                var response = _mapper.Map<ReadUserResponse>(mappedRequest);

                // トランザクションをコミット
                scope.Complete();
                
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ユーザーの作成中にエラーが発生しました。");
                throw new Exception("ユーザーの作成中にエラーが発生しました。", ex);
            }
        }
    }
}
