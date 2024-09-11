using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingLots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlateNumber = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parkingSpaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parkingLotId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parkingSpaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parkingSpaces_parkingLots_parkingLotId",
                        column: x => x.parkingLotId,
                        principalTable: "parkingLots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ParkingTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false),
                    ParkingSpaceId = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingTransactions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ParkingTransactions_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingTransactions_parkingSpaces_ParkingSpaceId",
                        column: x => x.ParkingSpaceId,
                        principalTable: "parkingSpaces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_parkingSpaces_parkingLotId",
                table: "parkingSpaces",
                column: "parkingLotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTransactions_ParkingSpaceId",
                table: "ParkingTransactions",
                column: "ParkingSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTransactions_VehicleId",
                table: "ParkingTransactions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTransactions_VehiclesId",
                table: "ParkingTransactions",
                column: "VehiclesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingTransactions");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "parkingSpaces");

            migrationBuilder.DropTable(
                name: "parkingLots");
        }
    }
}
