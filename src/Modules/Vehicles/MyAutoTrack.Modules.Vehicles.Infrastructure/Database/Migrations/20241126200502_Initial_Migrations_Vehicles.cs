using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migrations_Vehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vehicles");

            migrationBuilder.CreateTable(
                name: "manufacturer",
                schema: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_manufacturer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                schema: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_owner", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                schema: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    fabrication_year = table.Column<int>(type: "integer", nullable: false),
                    mileage = table.Column<long>(type: "bigint", nullable: false),
                    license_plate = table.Column<string>(type: "text", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    manufacturer_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicles_manufacturer_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalSchema: "vehicles",
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicles_owner_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "vehicles",
                        principalTable: "owner",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_manufacturer_id",
                schema: "vehicles",
                table: "vehicles",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_owner_id",
                schema: "vehicles",
                table: "vehicles",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "manufacturer",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "owner",
                schema: "vehicles");
        }
    }
}
