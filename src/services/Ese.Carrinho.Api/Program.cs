using Ese.Carrinho.Api.Configuration;
using Ese.WebApi.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiConfiguration();
builder.AddSwaggerConfiguration();
builder.AddJwtConfiguration();
builder.RegisterServices();
builder.AddMessageBusConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfiguration();

app.Run();
