using Microsoft.EntityFrameworkCore;
using DartApp.Models;

namespace DartApp.Data
{
    public class DartAppContext : DbContext
    {
        public DartAppContext(DbContextOptions<DartAppContext> options) : base(options)
        {
        }

        // Database Sets
        public DbSet<Game> Games { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configureer de discriminator
            modelBuilder.Entity<GameMode>()
                .HasDiscriminator<int>("GameModeType")
                .HasValue<GameMode301>(1)
                .HasValue<GameMode501>(2)
                .HasValue<Tactics>(3);

            // Voeg seed data toe aan de afgeleide klassen
            modelBuilder.Entity<GameMode301>().HasData(
                new GameMode301 { GameModeId = 1, Name = "301" }
            );

            modelBuilder.Entity<GameMode501>().HasData(
                new GameMode501 { GameModeId = 2, Name = "501" }
            );

            modelBuilder.Entity<Tactics>().HasData(
                new Tactics { GameModeId = 3, Name = "Tactics" }
            );

            // Voeg optioneel andere seed data toe
            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, GameModeId = 1 }
            );

            modelBuilder.Entity<Player>().HasData(
                new Player { PlayerId = 1, Name = "Speler 1", Score = 301, GameId = 1 },
                new Player { PlayerId = 2, Name = "Speler 2", Score = 301, GameId = 1 }
            );
        }

    }
}
