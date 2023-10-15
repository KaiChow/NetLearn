using EFCoreNet.API.Config;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // ���÷��ص�json���ݺ�ģ�͵ĸ�ʽһ��
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    // ����ʱ���ͳһ���ظ�ʽ
    options.SerializerSettings.DateFormatString = "yyyy:MM:dd HH:mm:ss";
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // ����swagger��Ĭ�Ϸ�������
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
