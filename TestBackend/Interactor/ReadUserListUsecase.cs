using TestBackend.Interfaces;
using TestBackend.Usecases;
using TestBackend.Interactor.Dtos;
using TestBackend.Models.Entities;
using Azure;
using TestBackend.Configrations.Configurations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestBackend.Data;

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
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<List<ReadUserResponse>> ExcuteAsync()
    {
        // データベースからユーザー一覧を取得するロジック
        var user = await _userRepository.GetAllAsync();

        var response = _mapper.Map<List<ReadUserResponse>>(user);

        return response;
    }
}
