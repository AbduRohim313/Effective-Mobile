using Effective_Mobile.Interfaces;
using Effective_Mobile.Reository;
using Effective_Mobile.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, HomeService>();

builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();