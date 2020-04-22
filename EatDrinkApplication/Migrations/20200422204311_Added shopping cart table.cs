using Microsoft.EntityFrameworkCore.Migrations;

namespace EatDrinkApplication.Migrations
{
    public partial class Addedshoppingcarttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02efc056-49e2-4a4c-9b09-57b80603bae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a6f78b-7610-45da-b744-7757bdec4eeb");

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeCookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_HomeCook_HomeCookId",
                        column: x => x.HomeCookId,
                        principalTable: "HomeCook",
                        principalColumn: "HomeCookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcf896d7-b953-4555-9bd4-6a8adf70f862", "9485b8ff-f525-41de-b534-bcef0e8d71ee", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66edab0e-d3c5-4736-a579-d3b55ba6b002", "97e761e0-b3d4-4b6a-a9bb-6b25012289f5", "HomeCook", "HOMECOOK" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_HomeCookId",
                table: "ShoppingCart",
                column: "HomeCookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66edab0e-d3c5-4736-a579-d3b55ba6b002");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf896d7-b953-4555-9bd4-6a8adf70f862");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02efc056-49e2-4a4c-9b09-57b80603bae4", "b9d8b9d0-6942-44e1-b367-70fd56baa4a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2a6f78b-7610-45da-b744-7757bdec4eeb", "d22d74bf-3781-4442-bdb7-513ea2d7719f", "HomeCook", "HOMECOOK" });
        }
    }
}
