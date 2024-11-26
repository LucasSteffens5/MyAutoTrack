using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAutoTrack.Modules.Vehicles.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Inbox_and_Outbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_manufacturer_manufacturer_id",
                schema: "vehicles",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_owner_owner_id",
                schema: "vehicles",
                table: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_owner",
                schema: "vehicles",
                table: "owner");

            migrationBuilder.DropPrimaryKey(
                name: "pk_manufacturer",
                schema: "vehicles",
                table: "manufacturer");

            migrationBuilder.RenameTable(
                name: "owner",
                schema: "vehicles",
                newName: "owners",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "manufacturer",
                schema: "vehicles",
                newName: "manufacturers",
                newSchema: "vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "pk_owners",
                schema: "vehicles",
                table: "owners",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_manufacturers",
                schema: "vehicles",
                table: "manufacturers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "inbox_message_consumers",
                schema: "vehicles",
                columns: table => new
                {
                    inbox_message_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inbox_message_consumers", x => new { x.inbox_message_id, x.name });
                });

            migrationBuilder.CreateTable(
                name: "inbox_messages",
                schema: "vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "jsonb", maxLength: 2000, nullable: false),
                    occurred_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    processed_on_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inbox_messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "outbox_message_consumers",
                schema: "vehicles",
                columns: table => new
                {
                    outbox_message_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_outbox_message_consumers", x => new { x.outbox_message_id, x.name });
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_manufacturers_manufacturer_id",
                schema: "vehicles",
                table: "vehicles",
                column: "manufacturer_id",
                principalSchema: "vehicles",
                principalTable: "manufacturers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_owners_owner_id",
                schema: "vehicles",
                table: "vehicles",
                column: "owner_id",
                principalSchema: "vehicles",
                principalTable: "owners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_manufacturers_manufacturer_id",
                schema: "vehicles",
                table: "vehicles");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_owners_owner_id",
                schema: "vehicles",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "inbox_message_consumers",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "inbox_messages",
                schema: "vehicles");

            migrationBuilder.DropTable(
                name: "outbox_message_consumers",
                schema: "vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_owners",
                schema: "vehicles",
                table: "owners");

            migrationBuilder.DropPrimaryKey(
                name: "pk_manufacturers",
                schema: "vehicles",
                table: "manufacturers");

            migrationBuilder.RenameTable(
                name: "owners",
                schema: "vehicles",
                newName: "owner",
                newSchema: "vehicles");

            migrationBuilder.RenameTable(
                name: "manufacturers",
                schema: "vehicles",
                newName: "manufacturer",
                newSchema: "vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "pk_owner",
                schema: "vehicles",
                table: "owner",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_manufacturer",
                schema: "vehicles",
                table: "manufacturer",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_manufacturer_manufacturer_id",
                schema: "vehicles",
                table: "vehicles",
                column: "manufacturer_id",
                principalSchema: "vehicles",
                principalTable: "manufacturer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_owner_owner_id",
                schema: "vehicles",
                table: "vehicles",
                column: "owner_id",
                principalSchema: "vehicles",
                principalTable: "owner",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
