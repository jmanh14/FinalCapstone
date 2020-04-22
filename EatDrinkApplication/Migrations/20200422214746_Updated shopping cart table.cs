using Microsoft.EntityFrameworkCore.Migrations;

namespace EatDrinkApplication.Migrations
{
    public partial class Updatedshoppingcarttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66edab0e-d3c5-4736-a579-d3b55ba6b002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf896d7-b953-4555-9bd4-6a8adf70f862");

            migrationBuilder.AddColumn<string>(
                name: "Items",
                table: "ShoppingCart",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f49a8502-de5c-49c3-9926-482453a95dbd", "79405f25-c00e-4b31-91a3-7be2eb420466", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "134a0beb-d3eb-4f91-9dbc-3e378120bcbd", "e422d080-a910-4b41-80bd-c83bc8b080a8", "HomeCook", "HOMECOOK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134a0beb-d3eb-4f91-9dbc-3e378120bcbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f49a8502-de5c-49c3-9926-482453a95dbd");

            migrationBuilder.DropColumn(
                name: "Items",
                table: "ShoppingCart");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcf896d7-b953-4555-9bd4-6a8adf70f862", "9485b8ff-f525-41de-b534-bcef0e8d71ee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66edab0e-d3c5-4736-a579-d3b55ba6b002", "97e761e0-b3d4-4b6a-a9bb-6b25012289f5", "HomeCook", "HOMECOOK" });
        }
    }
}
