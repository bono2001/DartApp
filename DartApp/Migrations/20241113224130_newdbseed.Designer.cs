﻿// <auto-generated />
using DartApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DartApp.Migrations
{
    [DbContext(typeof(DartAppContext))]
    [Migration("20241113224130_newdbseed")]
    partial class newdbseed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DartApp.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<int>("GameModeId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("GameModeId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GameModeId = 1
                        });
                });

            modelBuilder.Entity("DartApp.Models.GameMode", b =>
                {
                    b.Property<int>("GameModeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameModeId"));

                    b.Property<int?>("CurrentTurnId")
                        .HasColumnType("int");

                    b.Property<int>("GameModeType")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameModeId");

                    b.HasIndex("CurrentTurnId");

                    b.ToTable("GameModes");

                    b.HasDiscriminator<int>("GameModeType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DartApp.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("GameModeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("GameId");

                    b.HasIndex("GameModeId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            GameId = 1,
                            Name = "Speler 1",
                            Score = 301
                        },
                        new
                        {
                            PlayerId = 2,
                            GameId = 1,
                            Name = "Speler 2",
                            Score = 301
                        });
                });

            modelBuilder.Entity("DartApp.Models.TacticsTarget", b =>
                {
                    b.Property<int>("TacticsTargetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TacticsTargetId"));

                    b.Property<int>("HitsMade")
                        .HasColumnType("int");

                    b.Property<int>("HitsRequired")
                        .HasColumnType("int");

                    b.Property<int>("TacticsId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("TacticsTargetId");

                    b.HasIndex("TacticsId");

                    b.ToTable("TacticsTarget");
                });

            modelBuilder.Entity("DartApp.Models.GameMode301", b =>
                {
                    b.HasBaseType("DartApp.Models.GameMode");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            GameModeId = 1,
                            IsFinished = false,
                            Name = "301"
                        });
                });

            modelBuilder.Entity("DartApp.Models.GameMode501", b =>
                {
                    b.HasBaseType("DartApp.Models.GameMode");

                    b.HasDiscriminator().HasValue(2);

                    b.HasData(
                        new
                        {
                            GameModeId = 2,
                            IsFinished = false,
                            Name = "501"
                        });
                });

            modelBuilder.Entity("Tactics", b =>
                {
                    b.HasBaseType("DartApp.Models.GameMode");

                    b.HasDiscriminator().HasValue(3);

                    b.HasData(
                        new
                        {
                            GameModeId = 3,
                            IsFinished = false,
                            Name = "Tactics"
                        });
                });

            modelBuilder.Entity("DartApp.Models.Game", b =>
                {
                    b.HasOne("DartApp.Models.GameMode", "GameMode")
                        .WithMany()
                        .HasForeignKey("GameModeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameMode");
                });

            modelBuilder.Entity("DartApp.Models.GameMode", b =>
                {
                    b.HasOne("DartApp.Models.Player", "CurrentTurn")
                        .WithMany()
                        .HasForeignKey("CurrentTurnId");

                    b.Navigation("CurrentTurn");
                });

            modelBuilder.Entity("DartApp.Models.Player", b =>
                {
                    b.HasOne("DartApp.Models.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DartApp.Models.GameMode", null)
                        .WithMany("Players")
                        .HasForeignKey("GameModeId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("DartApp.Models.TacticsTarget", b =>
                {
                    b.HasOne("Tactics", "Tactics")
                        .WithMany("TacticsTargets")
                        .HasForeignKey("TacticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tactics");
                });

            modelBuilder.Entity("DartApp.Models.Game", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("DartApp.Models.GameMode", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("Tactics", b =>
                {
                    b.Navigation("TacticsTargets");
                });
#pragma warning restore 612, 618
        }
    }
}
