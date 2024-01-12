using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CelestialandTelescope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CelestialId",
                table: "Telescopes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telescopes_CelestialId",
                table: "Telescopes",
                column: "CelestialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Telescopes_CelestialBodies_CelestialId",
                table: "Telescopes",
                column: "CelestialId",
                principalTable: "CelestialBodies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telescopes_CelestialBodies_CelestialId",
                table: "Telescopes");

            migrationBuilder.DropIndex(
                name: "IX_Telescopes_CelestialId",
                table: "Telescopes");

            migrationBuilder.DropColumn(
                name: "CelestialId",
                table: "Telescopes");
        }
    }
}
