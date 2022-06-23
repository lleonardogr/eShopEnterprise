using Ese.WebApp.Mvc.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.RegisterServices();
builder.AddMvcConfiguration();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
