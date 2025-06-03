using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CommentUseerName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3124f3e4-b08f-4120-bcc9-ae40ff573707");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a8648d7-8a1b-4641-bf4d-eb46df1cee31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64f8e0ea-4d45-4153-8532-ca0736433ac9", null, "User", "USER" },
                    { "bd3875e9-9d01-4c1c-9e24-197de5e95e3b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f8e0ea-4d45-4153-8532-ca0736433ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd3875e9-9d01-4c1c-9e24-197de5e95e3b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3124f3e4-b08f-4120-bcc9-ae40ff573707", null, "Admin", "ADMIN" },
                    { "7a8648d7-8a1b-4641-bf4d-eb46df1cee31", null, "User", "USER" }
                });
        }
    }
}
