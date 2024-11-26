using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixingBookMapers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f8e0ea-4d45-4153-8532-ca0736433ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd3875e9-9d01-4c1c-9e24-197de5e95e3b");

            migrationBuilder.AlterColumn<int>(
                name: "Cover",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e3b1c15-682b-41ea-b8b0-1cfee4986373", null, "User", "USER" },
                    { "6672ec39-cac4-4a53-a8b0-c280fa520fa2", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e3b1c15-682b-41ea-b8b0-1cfee4986373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6672ec39-cac4-4a53-a8b0-c280fa520fa2");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Cover",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64f8e0ea-4d45-4153-8532-ca0736433ac9", null, "User", "USER" },
                    { "bd3875e9-9d01-4c1c-9e24-197de5e95e3b", null, "Admin", "ADMIN" }
                });
        }
    }
}
