using Microsoft.EntityFrameworkCore;
using BGU.Database.Postgres.Entities;

namespace BGU.Database.Postgres;

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
