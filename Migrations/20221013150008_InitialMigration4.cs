using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsedCars.Migrations
{
    public partial class InitialMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalEquipmentVehicle");

            migrationBuilder.CreateTable(
                name: "VehicleEquipments",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalEquipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleEquipments", x => new { x.VehicleId, x.AdditionalEquipmentId });
                    table.ForeignKey(
                        name: "FK_VehicleEquipments_AdditionalEquipments_AdditionalEquipmentId",
                        column: x => x.AdditionalEquipmentId,
                        principalTable: "AdditionalEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleEquipments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEquipments_AdditionalEquipmentId",
                table: "VehicleEquipments",
                column: "AdditionalEquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleEquipments");

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
    }
}
