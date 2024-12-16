using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyAutoTrack.Modules.Users.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Add_Permissions_Maintenance_Module : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "users",
                table: "permissions",
                column: "code",
                values: new object[]
                {
                    "maintenance:read",
                    "maintenance:update"
                });

            migrationBuilder.InsertData(
                schema: "users",
                table: "role_permissions",
                columns: new[] { "permission_code", "role_name" },
                values: new object[,]
                {
                    { "maintenance:read", "Administrator" },
                    { "maintenance:read", "Member" },
                    { "maintenance:update", "Administrator" },
                    { "maintenance:update", "Member" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "users",
                table: "role_permissions",
                keyColumns: new[] { "permission_code", "role_name" },
                keyValues: new object[] { "maintenance:read", "Administrator" });

            migrationBuilder.DeleteData(
                schema: "users",
                table: "role_permissions",
                keyColumns: new[] { "permission_code", "role_name" },
                keyValues: new object[] { "maintenance:read", "Member" });

            migrationBuilder.DeleteData(
                schema: "users",
                table: "role_permissions",
                keyColumns: new[] { "permission_code", "role_name" },
                keyValues: new object[] { "maintenance:update", "Administrator" });

            migrationBuilder.DeleteData(
                schema: "users",
                table: "role_permissions",
                keyColumns: new[] { "permission_code", "role_name" },
                keyValues: new object[] { "maintenance:update", "Member" });

            migrationBuilder.DeleteData(
                schema: "users",
                table: "permissions",
                keyColumn: "code",
                keyValue: "maintenance:read");

            migrationBuilder.DeleteData(
                schema: "users",
                table: "permissions",
                keyColumn: "code",
                keyValue: "maintenance:update");
        }
    }
}
