using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Gamesendpoints;
using GameStore.Api.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, InMemoryGamesRepository>();


var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddDbContext<GameStoreContext>(options => options.UseSqlServer(connString));
var app = builder.Build();
app.MapGroup("/")
   .MapGameEndpoints();
app.Run();
