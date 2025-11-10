using InvestAdvisor.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultExtensions();

builder.Services.AddOwnExtensions(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();