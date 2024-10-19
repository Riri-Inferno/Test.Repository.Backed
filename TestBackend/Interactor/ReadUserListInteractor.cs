using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TestBackend.Interactor;

public class ReadUserListInteractor : IReadUserListUsecase
{
    private readonly IGenericReadRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public ReadUserListInteractor(
        IGenericReadRepository<User> userRepository,
        IMapper mapper
    )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Userレコード一覧取得クエリ
    /// </summary>
    /// <returns></returns>
    public async Task<List<ReadUserResponse>> ExecuteAsync()
    {
        var usersQueryable = await _userRepository.GetQueryableAsync().ToListAsync();
        var response = _mapper.Map<List<ReadUserResponse>>(usersQueryable);

        return response;
    }
}
