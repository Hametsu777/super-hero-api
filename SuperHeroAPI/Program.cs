//global using SuperHeroAPI.Models;
// Need to install Nuget packages, EntityFrameworkCore, Design, and Entity.Npgsql(or equivalent database).
// After DataContext is set up, need to run the command dotnet ef migrations add InitialCreate in PM Console to
// get migrations folder. In that folder, Initial Create(SQL) is our created table in the database.

using SuperHeroAPI.Data;
using SuperHeroAPI.Services.SuperHeroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Have to add/register the services that I created (ISuperHeroService and SuperHeroService) to the program file.
// Need to learn about AddScope, AddSingleton, and AddTransient. Whenever a controller, etc wants to inject ISuperHeroService
// it knows to use SuperHeroService implementation.
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
// Need to register DbContext/DataContext.
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
