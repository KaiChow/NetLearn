using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserMgr.Domain;
using UserMgr.Infrastracture;
using UserMgr.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection"));
});
// 注册filtter
builder.Services.Configure<MvcOptions>(o =>
{
    o.Filters.Add<UnitOfWordFilter>();
});
// 事件监听
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var app = builder.Build();
// 注册服务
builder.Services.AddScoped<UserDomainService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodeSender>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
