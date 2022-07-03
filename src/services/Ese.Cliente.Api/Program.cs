using Ese.Cliente.Api.Configuration;
using Ese.WebApi.Core.Identidade;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiConfiguration();
builder.AddSwaggerConfiguration();
builder.AddJwtConfiguration();
builder.Services.AddMediatR(typeof(Program));
builder.RegisterServices();
builder.AddMessageBusConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfiguration();

app.Run();

