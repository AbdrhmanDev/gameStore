using GameStore.Api.Entities;

namespace GameStore.Api.Repository;

public interface IGamesRepository
{
    void CreateGame(Game game);
    void DeleteGame(int id);
    IEnumerable<Game> GetAllGames();
    Game? GetGameById(int id);
    void UpdateGame(Game game);
}
