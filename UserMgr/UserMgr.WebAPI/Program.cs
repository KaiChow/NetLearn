using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
// ×¢²áfiltter
builder.Services.Configure<MvcOptions>(o =>
{
    o.Filters.Add<UnitOfWordFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
