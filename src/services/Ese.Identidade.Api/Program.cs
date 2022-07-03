using Ese.Identidade.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddIdentityConfiguration();
builder.AddApiConfiguration();
builder.AddSwaggerConfiguration();
builder.AddMessageBusConfiguration();

var app = builder.Build();

app.UseApiConfiguration();

app.Run();
