using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodies_Addresses_AddressId",
                table: "CelestialBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Telescopes_Addresses_AddressId",
                table: "Telescopes");

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodies_Addresses_AddressId",
                table: "CelestialBodies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telescopes_Addresses_AddressId",
                table: "Telescopes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CelestialBodies_Addresses_AddressId",
                table: "CelestialBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Telescopes_Addresses_AddressId",
                table: "Telescopes");

            migrationBuilder.AddForeignKey(
                name: "FK_CelestialBodies_Addresses_AddressId",
                table: "CelestialBodies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telescopes_Addresses_AddressId",
                table: "Telescopes",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
