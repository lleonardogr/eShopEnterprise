using Ese.Catalogo.Api.Configuration;
using Ese.Catalogo.Api.Data;
using Ese.Catalogo.Api.Data.Repository;
using Ese.Catalogo.Api.Models;
using Ese.WebApi.Core.Identidade;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddApiConfiguration();
builder.AddJwtConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiConfiguration();

app.Run();
