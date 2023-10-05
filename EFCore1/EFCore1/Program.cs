using EFCore1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
/*
string connStr = "Server=localhost;Database=SystemAdmin;Uid=sa;Pwd=zk123456;Trusted_Connection=True;";
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer(connStr));
*/

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}
app.MapControllers();

app.Run();
