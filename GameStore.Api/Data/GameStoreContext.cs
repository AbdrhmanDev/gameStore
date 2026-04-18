using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext:DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options):base(options)
    {
        
    }

    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().Property(Game=>Game.Price).HasPrecision(18,2);
    }
    
}