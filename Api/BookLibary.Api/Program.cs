using BookLibary.Api.Data.Context;
using BookLibary.Api.Models;
using BookLibary.Api.Repositories;
using BookLibary.Api.Services.AuthServices;
using BookLibary.Api.Services.AuthServices.LoginServices;
using BookLibary.Api.Services.AuthServices.RegisterServices;
using BookLibary.Api.Services.AuthServices.TokenServices;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IUserRepository<User>, LoginRepository>();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ITokenService, TokenService>();



builder.Services.AddScoped<IRegisterRepository<User>, RegisterRepository>();
builder.Services.AddScoped<IRegisterService, RegisterService>();


builder.Services.AddScoped<IRepository<Book>, MongoRepositoryBase<Book>>();
builder.Services.AddScoped<BookService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed the database with initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
