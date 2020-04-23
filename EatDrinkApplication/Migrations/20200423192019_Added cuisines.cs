using Microsoft.EntityFrameworkCore.Migrations;

namespace EatDrinkApplication.Migrations
{
    public partial class Addedcuisines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134a0beb-d3eb-4f91-9dbc-3e378120bcbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f49a8502-de5c-49c3-9926-482453a95dbd");

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisinesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisinesId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bc2f3ec-3bbd-4bb4-8631-e8fcfb2fcfad", "bc5484d2-fc47-4257-bf01-c7980201b8e3", "HomeCook", "HOMECOOK" },
                    { "3c4f4cf0-7e7c-43ea-9245-26108af94491", "a117e65c-1d65-4773-bfab-6c50302b6a9f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "CuisinesId", "Name" },
                values: new object[,]
                {
                    { 26, "Vietnamese" },
                    { 25, "Thai" },
                    { 24, "Spanish" },
                    { 23, "Southern" },
                    { 22, "Nordic" },
                    { 21, "Middle Eastern" },
                    { 20, "Mexican" },
                    { 19, "Mediterranean" },
                    { 18, "Latin American" },
                    { 17, "Korean" },
                    { 16, "Jewish" },
                    { 15, "Japanese" },
                    { 14, "Italian" },
                    { 12, "Indian" },
                    { 11, "Greek" },
                    { 10, "German" },
                    { 9, "French" },
                    { 8, "European" },
                    { 7, "Eastern European" },
                    { 6, "Chinese" },
                    { 5, "Caribbean" },
                    { 4, "Cajun" },
                    { 3, "British" },
                    { 2, "American" },
                    { 13, "Irish" },
                    { 1, "Africian" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c4f4cf0-7e7c-43ea-9245-26108af94491");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bc2f3ec-3bbd-4bb4-8631-e8fcfb2fcfad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f49a8502-de5c-49c3-9926-482453a95dbd", "79405f25-c00e-4b31-91a3-7be2eb420466", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "134a0beb-d3eb-4f91-9dbc-3e378120bcbd", "e422d080-a910-4b41-80bd-c83bc8b080a8", "HomeCook", "HOMECOOK" });
        }
    }
}
