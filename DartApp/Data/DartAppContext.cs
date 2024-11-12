using Microsoft.EntityFrameworkCore;
using DartApp.Models;
using System.Numerics;

namespace DartApp.Data
{
    public class DartAppContext : DbContext
    {
        public DartAppContext(DbContextOptions<DartAppContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<GameMode> GameModes { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TacticsTarget> TacticsTargets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Per Hierarchy (TPH) configuratie
            modelBuilder.Entity<GameMode>()
                .HasDiscriminator<int>("GameModeType")
                .HasValue<GameMode301>(1)
                .HasValue<GameMode501>(2)
                .HasValue<Tactics>(3);

            // GameMode -> Player (CurrentTurn) relatie
            modelBuilder.Entity<GameMode>()
                .HasOne(g => g.CurrentTurn)
                .WithMany()
                .HasForeignKey(g => g.CurrentTurnId)
                .OnDelete(DeleteBehavior.Restrict); // Zorgt ervoor dat CurrentTurn geen cascade delete veroorzaakt

            // Game -> Players relatie
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Players)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId);

            // Tactics -> TacticsTargets relatie
            modelBuilder.Entity<Tactics>()
                .HasMany(t => t.TacticsTargets)
                .WithOne(tt => tt.Tactics)
                .HasForeignKey(tt => tt.TacticsId)
                .OnDelete(DeleteBehavior.Cascade);

            // Primaire sleutel voor TacticsTarget
            modelBuilder.Entity<TacticsTarget>()
                .HasKey(t => t.TacticsTargetId);

            // Tabelnamen instellen
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<GameMode>().ToTable("GameModes");
            modelBuilder.Entity<Player>().ToTable("Players");
            modelBuilder.Entity<TacticsTarget>().ToTable("TacticsTargets");
        }
    }
}
