using EFCoreNet.API.Config;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // 设置返回的json数据和模型的格式一致
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    // 设置时间额统一返回格式
    options.SerializerSettings.DateFormatString = "yyyy:MM:dd HH:mm:ss";
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // 设置swagger的默认返回数据
    options.SchemaFilter<DefaultValueSchemaFilter>();

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
