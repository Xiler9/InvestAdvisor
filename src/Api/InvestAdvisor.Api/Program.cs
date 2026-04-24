using InvestAdvisor.Api.Extensions;
using InvestAdvisor.Api.Middlewares;
using InvestAdvisor.Api.Models;

var builder = WebApplication.CreateBuilder(args);

//TODO добавить комментарии <summary>, <param>, <returns>, <exception>
//TODO добавить валидацую для новых DTOs
//TODO добавить логирование

builder.Services.AddDefaultExtensions();

builder.Services.AddOwnExtensions(builder);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<JwtAthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();