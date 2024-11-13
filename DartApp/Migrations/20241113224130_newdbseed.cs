using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DartApp.Migrations
{
    /// <inheritdoc />
    public partial class newdbseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes");

            migrationBuilder.DropForeignKey(
                name: "FK_TacticsTargets_GameModes_TacticsId",
                table: "TacticsTargets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TacticsTargets",
                table: "TacticsTargets");

            migrationBuilder.RenameTable(
                name: "TacticsTargets",
                newName: "TacticsTarget");

            migrationBuilder.RenameIndex(
                name: "IX_TacticsTargets_TacticsId",
                table: "TacticsTarget",
                newName: "IX_TacticsTarget_TacticsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TacticsTarget",
                table: "TacticsTarget",
                column: "TacticsTargetId");

            migrationBuilder.InsertData(
                table: "GameModes",
                columns: new[] { "GameModeId", "CurrentTurnId", "GameModeType", "IsFinished", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, false, "301" },
                    { 2, null, 2, false, "501" },
                    { 3, null, 3, false, "Tactics" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameModeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "GameId", "GameModeId", "Name", "Score" },
                values: new object[,]
                {
                    { 1, 1, null, "Speler 1", 301 },
                    { 2, 1, null, "Speler 2", 301 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes",
                column: "CurrentTurnId",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TacticsTarget_GameModes_TacticsId",
                table: "TacticsTarget",
                column: "TacticsId",
                principalTable: "GameModes",
                principalColumn: "GameModeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes");

            migrationBuilder.DropForeignKey(
                name: "FK_TacticsTarget_GameModes_TacticsId",
                table: "TacticsTarget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TacticsTarget",
                table: "TacticsTarget");

            migrationBuilder.DeleteData(
                table: "GameModes",
                keyColumn: "GameModeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GameModes",
                keyColumn: "GameModeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GameModes",
                keyColumn: "GameModeId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "TacticsTarget",
                newName: "TacticsTargets");

            migrationBuilder.RenameIndex(
                name: "IX_TacticsTarget_TacticsId",
                table: "TacticsTargets",
                newName: "IX_TacticsTargets_TacticsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TacticsTargets",
                table: "TacticsTargets",
                column: "TacticsTargetId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameModes_Players_CurrentTurnId",
                table: "GameModes",
                column: "CurrentTurnId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TacticsTargets_GameModes_TacticsId",
                table: "TacticsTargets",
                column: "TacticsId",
                principalTable: "GameModes",
                principalColumn: "GameModeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
