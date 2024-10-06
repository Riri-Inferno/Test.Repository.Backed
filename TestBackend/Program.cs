using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TestBackend.Controllers;
using TestBackend.Models;
using Microsoft.Extensions.Configuration;
using TestBackend.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using TestBackend.Interfaces;
using TestBackend.Repositories;
using TestBackend.Usecases;
using TestBackend.Interactor;
using AutoMapper;
using TestBackend.Configrations;
using TestBackend.Configrations.Configurations;
using TestBackend.Interactor.Dtos;
using Microsoft.AspNetCore.Mvc;
using TestBackend.Models.Entities;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

var builder = WebApplication.CreateBuilder(args);

// credentials.json から設定を読み込む
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("credentials.json", optional: false, reloadOnChange: true);

// appsettings.json も読み込む
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

// credentials.json から接続情報を取得
var endpoint = builder.Configuration["endpoint"];
var user = builder.Configuration["user"];
var password = builder.Configuration["password"];

// PostgreSQL用の接続文字列を生成
var connectionString = $"Host={endpoint};Port=5432;Database=postgres;Username={user};Password={password}";

// 接続文字列を使用してサービスに PostgreSQL コンテキストを登録
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString),
    ServiceLifetime.Scoped);



//Todo:エラーページのミドルウェアを追加する。以下のように追加
// エラーページのミドルウェアを追加
// app.UseDeveloperExceptionPage(); // 開発環境での詳細なエラーページ

// QueryとMutationのスキーマ登録
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<MutationCreate>()
    .AddType<ReadUserResponse>()
    .AddType<CreateUserRequest>();

// 追加するリポジトリの登録
builder.Services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
builder.Services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));

// Usecaseなど
builder.Services.AddScoped<IUserReadUsecase, UserReadInteractor>();
builder.Services.AddScoped<ICreateUserUsecase, CreateUserInteractor>();

// DBcontext?
// builder.Services.AddScoped<IGenericReadRepository<User>, GenericReadRepository<User>>();
// builder.Services.AddDbContext<User>(opt => opt.UseNpgsql(MyDbContext));

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AutoMapperUserProfile>();
});

var app = builder.Build();

// HTTPSリダイレクトの設定
app.UseHttpsRedirection();

// GraphQLエンドポイントを設定
app.MapGraphQL();

app.Run();
