using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Api.Entities;
using GameStore.Api.Repository;

namespace GameStore.Api.Gamesendpoints;

public static class GameEndpoints
{
    const string GetGameEndpoint = "getGame";


    public static RouteGroupBuilder MapGameEndpoints(this RouteGroupBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();
        group.MapGet("/", (IGamesRepository repository) => repository.GetAllGames());
        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.GetGameById(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();


        }).WithName(GetGameEndpoint);
        group.MapPost("/", (IGamesRepository repository, Game game) =>
        {
            repository
                .CreateGame(game);
            return Results.CreatedAtRoute(GetGameEndpoint, new { id = game.Id }, game);
        });
        group.MapPut("/{id}", (IGamesRepository repository, int id, Game updatedGane) =>
        {
            Game? existingGame = repository.GetGameById(id);
            if (existingGame == null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGane.Name;
            existingGame.Genre = updatedGane.Genre;
            existingGame.Price = updatedGane.Price;
            existingGame.ReleaseDate = updatedGane.ReleaseDate;
            existingGame.ImageUrl = updatedGane.ImageUrl;
            repository.UpdateGame(existingGame);
            return Results.Ok(existingGame);
        });
        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
          {
              Game? existingGame = repository.GetGameById(id);
              if (existingGame == null)
              {
                  return Results.NotFound();
              }
              repository.DeleteGame(id);
              return Results.NoContent();
          });
        return group;
    }

}
