using ReadmeGen.Services;
using ReadmeGen.DTOs;
using ReadmeGen.Controllers;
var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
// services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApiCallService, ApiCallService>();

var app = builder.Build();

app.MapControllers();

// middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
