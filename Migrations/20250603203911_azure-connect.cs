using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class azureconnect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd9a2607-2c64-46b4-a030-574116958852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ac2a6a-9e08-42bc-9e5d-280ac21a0725");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "192bd915-734b-4934-aa88-6cf1f7f077bd", null, "User", "USER" },
                    { "67db69eb-1f6a-4f30-aa5f-9ee3e583c182", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "192bd915-734b-4934-aa88-6cf1f7f077bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67db69eb-1f6a-4f30-aa5f-9ee3e583c182");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dd9a2607-2c64-46b4-a030-574116958852", null, "Admin", "ADMIN" },
                    { "f8ac2a6a-9e08-42bc-9e5d-280ac21a0725", null, "User", "USER" }
                });
        }
    }
}
