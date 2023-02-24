using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsedCars.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalEquipments_Vehicles_VehicleId",
                table: "AdditionalEquipments");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalEquipments_VehicleId",
                table: "AdditionalEquipments");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "AdditionalEquipments");

            migrationBuilder.CreateTable(
                name: "AdditionalEquipmentVehicle",
                columns: table => new
                {
                    AdditionalEquipmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalEquipmentVehicle", x => new { x.AdditionalEquipmentsId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_AdditionalEquipmentVehicle_AdditionalEquipments_AdditionalEquipmentsId",
                        column: x => x.AdditionalEquipmentsId,
                        principalTable: "AdditionalEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdditionalEquipmentVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalEquipmentVehicle_VehiclesId",
                table: "AdditionalEquipmentVehicle",
                column: "VehiclesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalEquipmentVehicle");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "AdditionalEquipments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalEquipments_VehicleId",
                table: "AdditionalEquipments",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalEquipments_Vehicles_VehicleId",
                table: "AdditionalEquipments",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
