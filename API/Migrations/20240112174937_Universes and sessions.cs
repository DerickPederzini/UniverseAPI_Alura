using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Universesandsessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CelestialId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sessions",
                newName: "AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Sessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                columns: new[] { "CelestialId", "AddressId" });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AddressId",
                table: "Sessions",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Addresses_AddressId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_AddressId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Sessions",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Sessions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CelestialId",
                table: "Sessions",
                column: "CelestialId");
        }
    }
}
