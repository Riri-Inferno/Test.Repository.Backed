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

public class UserReadInteractor : IUserReadUsecase
{
    private readonly IGenericReadRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserReadInteractor(
        IGenericReadRepository<User> userRepository,
        IMapper mapper
        )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Userレコード取得クエリ
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ReadUserResponse> ExcuteAsync(int id)
    {
        // データベースからユーザーを取得するロジック
        var user = await _userRepository.GetByIdAsync(id);
        
        // ユーザーが見つからない場合はエラーを投げる
        if (user == null)
        {
            throw new KeyNotFoundException($"User with ID {id} not found.");
        }

        var response = _mapper.Map<ReadUserResponse>(user);

        return response;
    }
}
