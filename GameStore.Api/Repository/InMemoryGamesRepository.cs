using GameStore.Api.Entities;

namespace GameStore.Api.Repository;

public class InMemoryGamesRepository : IGamesRepository
{
    private readonly List<Entities.Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "Minecraft",
        Genre = "Action",
        Price = 100.55m,
        ReleaseDate = DateTime.Now,
        ImageUrl = "https://posterhouse.org/wp-content/uploads/2021/05/silence_of_the_lambs_0.jpg"

    },
    new Game()
    {
        Id = 2,
        Name = "Moonlight",
        Genre = "Adventure",
        Price = 300m,
        ReleaseDate = new DateTime(2021, 5, 1),
        ImageUrl = "https://posterhouse.org/wp-content/uploads/2021/05/moonlight_0.jpg"
    }

};
    public IEnumerable<Game> GetAllGames()
    {
        return games;
    }
    public Game? GetGameById(int id)
    {
        return games.FirstOrDefault(game => game.Id == id);
    }
    public void CreateGame(Game game)
    {
        game.Id = games.Max(games => games.Id) + 1;
        games.Add(game);
    }
    public void UpdateGame(Game game)
    {
        var existingGame = games.Find(games => games.Id == game.Id);
        if (existingGame == null)
        {
            return;
        }
        existingGame.Name = game.Name;
        existingGame.Genre = game.Genre;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
        existingGame.ImageUrl = game.ImageUrl;
    }
    public void DeleteGame(int id)
    {
        var existingGame = games.Find(games => games.Id == id);
        if (existingGame == null)
        {
            return;
        }
        games.Remove(existingGame);
    }

}