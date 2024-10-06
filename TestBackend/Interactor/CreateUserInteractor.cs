using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;
using System.Data;

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
        var mappedRequest = _mapper.Map<User>(request);

        // ユーザー名またはメールアドレスが既に存在するか確認
        var existingUser = await _readUserRepository.FindAsync(
            e => e.UserName == request.Name || e.UserEmail == request.Email);

        // if (existingUser != null)
        // {
        //     if (existingUser.UserName == request.Name && existingUser.Email == request.Email)
        //     {
        //         throw new DuplicateNameException("このユーザー名とEmailアドレスはすでに登録されています");
        //     }
        //     else if (existingUser.Name == request.Name)
        //     {
        //         throw new DuplicateNameException("このユーザー名はすでに登録されています");
        //     }
        //     else if (existingUser.Email == request.Email)
        //     {
        //         throw new DuplicateNameException("このEmailアドレスはすでに登録されています");
        //     }
        // }

        await _writeUserRepository.AddAsync(mappedRequest);
        await _writeUserRepository.SaveChangesAsync();

        var createdUser = await _readUserRepository.GetByIdAsync(1);
        var response = _mapper.Map<ReadUserResponse>(createdUser);
        return response;
    }
}
