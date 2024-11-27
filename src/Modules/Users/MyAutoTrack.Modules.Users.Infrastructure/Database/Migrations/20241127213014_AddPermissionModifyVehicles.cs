using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAutoTrack.Modules.Users.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionModifyVehicles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "users",
                table: "role_permissions",
                columns: new[] { "permission_code", "role_name" },
                values: new object[] { "vehicles:update", "Member" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "users",
                table: "role_permissions",
                keyColumns: new[] { "permission_code", "role_name" },
                keyValues: new object[] { "vehicles:update", "Member" });
        }
    }
}
