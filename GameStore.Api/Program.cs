using GameStore.Api.Entities;
using GameStore.Api.Gamesendpoints;
using GameStore.Api.Repository;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();
var app = builder.Build();

app.MapGroup("/")
   .MapGameEndpoints();
app.Run();
