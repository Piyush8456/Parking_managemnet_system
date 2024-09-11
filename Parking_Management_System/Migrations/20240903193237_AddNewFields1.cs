using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "ParkingTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SpaceSize",
                table: "parkingSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailableSpaces",
                table: "parkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedSpaceSize",
                table: "parkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpaceSize",
                table: "parkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCapacity",
                table: "parkingLots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "ParkingTransactions");

            migrationBuilder.DropColumn(
                name: "SpaceSize",
                table: "parkingSpaces");

            migrationBuilder.DropColumn(
                name: "AvailableSpaces",
                table: "parkingLots");

            migrationBuilder.DropColumn(
                name: "SelectedSpaceSize",
                table: "parkingLots");

            migrationBuilder.DropColumn(
                name: "SpaceSize",
                table: "parkingLots");

            migrationBuilder.DropColumn(
                name: "TotalCapacity",
                table: "parkingLots");
        }
    }
}
