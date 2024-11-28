using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e3b1c15-682b-41ea-b8b0-1cfee4986373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6672ec39-cac4-4a53-a8b0-c280fa520fa2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471bf68a-c644-45ee-99c3-94dc69d2f330", null, "Admin", "ADMIN" },
                    { "d124627b-2527-4cf2-a010-126b3ce025fe", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471bf68a-c644-45ee-99c3-94dc69d2f330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d124627b-2527-4cf2-a010-126b3ce025fe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e3b1c15-682b-41ea-b8b0-1cfee4986373", null, "User", "USER" },
                    { "6672ec39-cac4-4a53-a8b0-c280fa520fa2", null, "Admin", "ADMIN" }
                });
        }
    }
}
