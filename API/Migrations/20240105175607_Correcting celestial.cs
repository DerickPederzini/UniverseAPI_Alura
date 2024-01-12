using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Correctingcelestial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_CelestialBodies_CelestialId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "CelestialId",
                table: "Sessions",
                newName: "CelestialId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_CelestialId",
                table: "Sessions",
                newName: "IX_Sessions_CelestialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_CelestialBodies_CelestialId",
                table: "Sessions",
                column: "CelestialId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_CelestialBodies_CelestialId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "CelestialId",
                table: "Sessions",
                newName: "CelestialId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_CelestialId",
                table: "Sessions",
                newName: "IX_Sessions_CelestialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_CelestialBodies_CelestialId",
                table: "Sessions",
                column: "CelestialId",
                principalTable: "CelestialBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
