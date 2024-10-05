using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;

namespace TestBackend.Interactor;

public class CreateUserInteractor : ICreateUserUsecase
{
    private readonly IGenericReadRepository<User> _userReadRepository;
    private readonly IGenericWriteRepository<User> _userWriteRepository;
    private readonly IMapper _mapper;

    public CreateUserInteractor(
        IGenericReadRepository<User> userReadRepository,
        IGenericWriteRepository<User> userWriteRepository,
        IMapper mapper
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// ユーザー作成
    /// </summary>
    /// <param name="request">ユーザー作成リクエスト</param>
    /// <returns>作成したユーザーレコード</returns>
    public async Task<ReadUserResponse> ExcuteAsync(CreateUserRequest request)
    {
        var CreateUser = _mapper.Map<User>(request);

        await _userWriteRepository.AddAsync(CreateUser);
        await _userWriteRepository.SaveChangesAsync();

        var createdUser = await _userReadRepository.GetByIdAsync(request.Id);
        var response = _mapper.Map<ReadUserResponse>(createdUser);

        return response;
    }
}
