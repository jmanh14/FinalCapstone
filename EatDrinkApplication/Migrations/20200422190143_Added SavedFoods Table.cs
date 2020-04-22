using Microsoft.EntityFrameworkCore.Migrations;

namespace EatDrinkApplication.Migrations
{
    public partial class AddedSavedFoodsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d258f7a-1f88-4a73-9a8b-8143e904e835");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7772f150-7e7b-400c-9643-74d8fc0d52e6");

            migrationBuilder.CreateTable(
                name: "SavedFoods",
                columns: table => new
                {
                    SavedFoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ingredients = table.Column<string>(nullable: true),
                    Recipe = table.Column<string>(nullable: true),
                    HomeCookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedFoods", x => x.SavedFoodsId);
                    table.ForeignKey(
                        name: "FK_SavedFoods_HomeCook_HomeCookId",
                        column: x => x.HomeCookId,
                        principalTable: "HomeCook",
                        principalColumn: "HomeCookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02efc056-49e2-4a4c-9b09-57b80603bae4", "b9d8b9d0-6942-44e1-b367-70fd56baa4a6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d2a6f78b-7610-45da-b744-7757bdec4eeb", "d22d74bf-3781-4442-bdb7-513ea2d7719f", "HomeCook", "HOMECOOK" });

            migrationBuilder.CreateIndex(
                name: "IX_SavedFoods_HomeCookId",
                table: "SavedFoods",
                column: "HomeCookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedFoods");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02efc056-49e2-4a4c-9b09-57b80603bae4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2a6f78b-7610-45da-b744-7757bdec4eeb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d258f7a-1f88-4a73-9a8b-8143e904e835", "d4da1abe-0a2e-4987-86b9-36bae7830a21", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7772f150-7e7b-400c-9643-74d8fc0d52e6", "7f8062e2-f8f1-4bf6-a1fa-3755c970b863", "HomeCook", "HOMECOOK" });
        }
    }
}
