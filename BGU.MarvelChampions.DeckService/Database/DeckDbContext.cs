using Microsoft.EntityFrameworkCore;
using BGU.MarvelChampions.DeckService.Database.Entities;

namespace BGU.MarvelChampions.DeckService.Database;

public class DeckDbContext : DbContext
{
    public DeckDbContext(DbContextOptions<DeckDbContext> options)
        : base(options)
    {
    }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }*/

    public DbSet<DeckEntity> Decks { get; set; }
}
