using Microsoft.EntityFrameworkCore.Migrations;

namespace EatDrinkApplication.Data.Migrations
{
    public partial class AddedHomeCookandCocktails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66ec8d0e-b140-4a93-b9c9-1fb681be9916");

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    CocktailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.CocktailsId);
                });

            migrationBuilder.CreateTable(
                name: "HomeCook",
                columns: table => new
                {
                    HomeCookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCook", x => x.HomeCookId);
                    table.ForeignKey(
                        name: "FK_HomeCook_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    DrinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strDrink = table.Column<string>(nullable: true),
                    strDrinkThumb = table.Column<string>(nullable: true),
                    idDrink = table.Column<string>(nullable: true),
                    CocktailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.DrinkId);
                    table.ForeignKey(
                        name: "FK_Drink_Cocktails_CocktailsId",
                        column: x => x.CocktailsId,
                        principalTable: "Cocktails",
                        principalColumn: "CocktailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "896cc1d8-c8e5-4748-83ba-95e809d79bdc", "6d7e5eab-7173-4027-95e9-6580f46c7457", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Drink_CocktailsId",
                table: "Drink",
                column: "CocktailsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCook_IdentityUserId",
                table: "HomeCook",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "HomeCook");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "896cc1d8-c8e5-4748-83ba-95e809d79bdc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66ec8d0e-b140-4a93-b9c9-1fb681be9916", "3e8924f7-db0f-490e-b544-a2c7866230bc", "Admin", "ADMIN" });
        }
    }
}
