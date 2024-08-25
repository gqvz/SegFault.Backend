
using System.Diagnostics;
using MongoDB.Driver;
using SegFault.Backend.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoClient>(provider => new MongoClient(provider.GetService<IConfiguration>()?["MONGODB_CONNECTION_URI"] ??throw new Exception("Mongo DB Connection string not found. Please set environment variable MONGODB_CONNECTION_URI")));
builder.Services.AddSingleton<UserService>(provider => new UserService(provider.GetService<MongoClient>() ?? throw new UnreachableException("This should never throw")));
builder.Services.AddSingleton<SessionService>(provider => new SessionService(provider.GetService<MongoClient>() ?? throw new UnreachableException("This should never throw")));
builder.Services.AddSingleton<MenuService>(provider => new MenuService(provider.GetService<MongoClient>() ?? throw new UnreachableException("This should never throw")));
builder.Services.AddSingleton<ReviewService>(provider => new ReviewService(provider.GetService<MongoClient>() ?? throw new UnreachableException("This should never throw")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();