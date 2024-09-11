using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerContact",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerContact",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Vehicles");
        }
    }
}
