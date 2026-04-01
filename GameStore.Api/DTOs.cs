using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api;

public record GameDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ImageUrl { get; set; } = String.Empty;
}
public record CreateGameDto
{
    public string Name { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ImageUrl { get; set; } = String.Empty;
}
public record UpdateGameDto
{
    public string Name { get; set; } = String.Empty;
    public string Genre { get; set; } = String.Empty;
    public decimal Price { get; set; }

    public string ImageUrl { get; set; } = String.Empty;
}