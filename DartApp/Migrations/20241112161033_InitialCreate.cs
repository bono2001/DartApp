using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DartApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameModes",
                columns: table => new
                {
                    GameModeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTurnId = table.Column<int>(type: "int", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    GameModeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModes", x => x.GameModeId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_GameModes_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameModes",
                        principalColumn: "GameModeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TacticsTargets",
                columns: table => new
                {
                    TacticsTargetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    HitsRequired = table.Column<int>(type: "int", nullable: false),
                    HitsMade = table.Column<int>(type: "int", nullable: false),
                    TacticsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacticsTargets", x => x.TacticsTargetId);
                    table.ForeignKey(
                        name: "FK_TacticsTargets_GameModes_TacticsId",
                        column: x => x.TacticsId,
                        principalTable: "GameModes",
                        principalColumn: "GameModeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GameModeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_GameModes_GameModeId",
                        column: x => x.GameModeId,
                        principalTable: "GameModes",
                        principalColumn: "GameModeId");
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameModes_CurrentTurnId",
                table: "GameModes",
                column: "CurrentTurnId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameModeId",
                table: "Games",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameModeId",
                table: "Players",
                column: "GameModeId");

            migrationBuilder.CreateIndex(
                name: "IX_TacticsTargets_TacticsId",
                table: "TacticsTargets",
                column: "TacticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes",
                column: "CurrentTurnId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes");

            migrationBuilder.DropTable(
                name: "TacticsTargets");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameModes");
        }
    }
}
