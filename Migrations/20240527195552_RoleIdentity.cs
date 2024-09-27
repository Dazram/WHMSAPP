using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Warehouse_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class RoleIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81d6c5e9-4924-475f-bb98-d226e428ff85", null, "Admin", "ADMIN" },
                    { "f0389f9d-5bce-4ef7-9301-377d2a2476b2", null, "User", "USER  " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81d6c5e9-4924-475f-bb98-d226e428ff85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0389f9d-5bce-4ef7-9301-377d2a2476b2");
        }
    }
}
