using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EatDrinkApplication.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CocktailDescription",
                columns: table => new
                {
                    CocktailDescriptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailDescription", x => x.CocktailDescriptionId);
                });

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
                name: "Foods",
                columns: table => new
                {
                    FoodsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodsId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IdIngredient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientsId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Mix",
                columns: table => new
                {
                    MixId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDrink = table.Column<string>(nullable: true),
                    strDrink = table.Column<string>(nullable: true),
                    strDrinkAlternate = table.Column<string>(nullable: true),
                    strDrinkES = table.Column<string>(nullable: true),
                    strDrinkDE = table.Column<string>(nullable: true),
                    strDrinkFR = table.Column<string>(nullable: true),
                    strDrinkZHHANS = table.Column<string>(nullable: true),
                    strDrinkZHHANT = table.Column<string>(nullable: true),
                    strTags = table.Column<string>(nullable: true),
                    strVideo = table.Column<string>(nullable: true),
                    strCategory = table.Column<string>(nullable: true),
                    strIBA = table.Column<string>(nullable: true),
                    strAlcoholic = table.Column<string>(nullable: true),
                    strGlass = table.Column<string>(nullable: true),
                    strInstructions = table.Column<string>(nullable: true),
                    strInstructionsES = table.Column<string>(nullable: true),
                    strInstructionsDE = table.Column<string>(nullable: true),
                    strInstructionsFR = table.Column<string>(nullable: true),
                    strInstructionsZHHANS = table.Column<string>(nullable: true),
                    strInstructionsZHHANT = table.Column<string>(nullable: true),
                    strDrinkThumb = table.Column<string>(nullable: true),
                    strIngredient1 = table.Column<string>(nullable: true),
                    strIngredient2 = table.Column<string>(nullable: true),
                    strIngredient3 = table.Column<string>(nullable: true),
                    strIngredient4 = table.Column<string>(nullable: true),
                    strIngredient5 = table.Column<string>(nullable: true),
                    strIngredient6 = table.Column<string>(nullable: true),
                    strIngredient7 = table.Column<string>(nullable: true),
                    strIngredient8 = table.Column<string>(nullable: true),
                    strIngredient9 = table.Column<string>(nullable: true),
                    strIngredient10 = table.Column<string>(nullable: true),
                    strIngredient11 = table.Column<string>(nullable: true),
                    strIngredient12 = table.Column<string>(nullable: true),
                    strIngredient13 = table.Column<string>(nullable: true),
                    strIngredient14 = table.Column<string>(nullable: true),
                    strIngredient15 = table.Column<string>(nullable: true),
                    strMeasure1 = table.Column<string>(nullable: true),
                    strMeasure2 = table.Column<string>(nullable: true),
                    strMeasure3 = table.Column<string>(nullable: true),
                    strMeasure4 = table.Column<string>(nullable: true),
                    strMeasure5 = table.Column<string>(nullable: true),
                    strMeasure6 = table.Column<string>(nullable: true),
                    strMeasure7 = table.Column<string>(nullable: true),
                    strMeasure8 = table.Column<string>(nullable: true),
                    strMeasure9 = table.Column<string>(nullable: true),
                    strMeasure10 = table.Column<string>(nullable: true),
                    strMeasure11 = table.Column<string>(nullable: true),
                    strMeasure12 = table.Column<string>(nullable: true),
                    strMeasure13 = table.Column<string>(nullable: true),
                    strMeasure14 = table.Column<string>(nullable: true),
                    strMeasure15 = table.Column<string>(nullable: true),
                    strCreativeCommonsConfirmed = table.Column<string>(nullable: true),
                    dateModified = table.Column<string>(nullable: true),
                    CocktailDescriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mix", x => x.MixId);
                    table.ForeignKey(
                        name: "FK_Mix_CocktailDescription_CocktailDescriptionId",
                        column: x => x.CocktailDescriptionId,
                        principalTable: "CocktailDescription",
                        principalColumn: "CocktailDescriptionId",
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

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    imageType = table.Column<string>(nullable: true),
                    usedIngredientCount = table.Column<int>(nullable: false),
                    missedIngredientCount = table.Column<int>(nullable: false),
                    likes = table.Column<int>(nullable: false),
                    FoodsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recipe_Foods_FoodsId",
                        column: x => x.FoodsId,
                        principalTable: "Foods",
                        principalColumn: "FoodsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavedDrinks",
                columns: table => new
                {
                    SavedDrinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ingredient1 = table.Column<string>(nullable: true),
                    Ingredient2 = table.Column<string>(nullable: true),
                    Ingredient3 = table.Column<string>(nullable: true),
                    Ingredient4 = table.Column<string>(nullable: true),
                    Ingredient5 = table.Column<string>(nullable: true),
                    Ingredient6 = table.Column<string>(nullable: true),
                    Ingredient7 = table.Column<string>(nullable: true),
                    Ingredient8 = table.Column<string>(nullable: true),
                    Ingredient9 = table.Column<string>(nullable: true),
                    Ingredient10 = table.Column<string>(nullable: true),
                    Ingredient11 = table.Column<string>(nullable: true),
                    Ingredient12 = table.Column<string>(nullable: true),
                    Ingredient13 = table.Column<string>(nullable: true),
                    Ingredient14 = table.Column<string>(nullable: true),
                    Ingredient15 = table.Column<string>(nullable: true),
                    Recipe = table.Column<string>(nullable: true),
                    HomeCookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedDrinks", x => x.SavedDrinksId);
                    table.ForeignKey(
                        name: "FK_SavedDrinks_HomeCook_HomeCookId",
                        column: x => x.HomeCookId,
                        principalTable: "HomeCook",
                        principalColumn: "HomeCookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Missedingredient",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissedingredientId = table.Column<int>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    unit = table.Column<string>(nullable: true),
                    unitLong = table.Column<string>(nullable: true),
                    unitShort = table.Column<string>(nullable: true),
                    aisle = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    original = table.Column<string>(nullable: true),
                    originalString = table.Column<string>(nullable: true),
                    originalName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    Recipeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missedingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Missedingredient_Recipe_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Unusedingredient",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnusedingredientId = table.Column<int>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    unit = table.Column<string>(nullable: true),
                    unitLong = table.Column<string>(nullable: true),
                    unitShort = table.Column<string>(nullable: true),
                    aisle = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    original = table.Column<string>(nullable: true),
                    originalString = table.Column<string>(nullable: true),
                    originalName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    Recipeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unusedingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Unusedingredient_Recipe_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usedingredient",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsedingredientId = table.Column<int>(nullable: false),
                    amount = table.Column<float>(nullable: false),
                    unit = table.Column<string>(nullable: true),
                    unitLong = table.Column<string>(nullable: true),
                    unitShort = table.Column<string>(nullable: true),
                    aisle = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    original = table.Column<string>(nullable: true),
                    originalString = table.Column<string>(nullable: true),
                    originalName = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    Recipeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usedingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Usedingredient_Recipe_Recipeid",
                        column: x => x.Recipeid,
                        principalTable: "Recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d258f7a-1f88-4a73-9a8b-8143e904e835", "d4da1abe-0a2e-4987-86b9-36bae7830a21", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7772f150-7e7b-400c-9643-74d8fc0d52e6", "7f8062e2-f8f1-4bf6-a1fa-3755c970b863", "HomeCook", "HOMECOOK" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_CocktailsId",
                table: "Drink",
                column: "CocktailsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeCook_IdentityUserId",
                table: "HomeCook",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missedingredient_Recipeid",
                table: "Missedingredient",
                column: "Recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_Mix_CocktailDescriptionId",
                table: "Mix",
                column: "CocktailDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_FoodsId",
                table: "Recipe",
                column: "FoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedDrinks_HomeCookId",
                table: "SavedDrinks",
                column: "HomeCookId");

            migrationBuilder.CreateIndex(
                name: "IX_Unusedingredient_Recipeid",
                table: "Unusedingredient",
                column: "Recipeid");

            migrationBuilder.CreateIndex(
                name: "IX_Usedingredient_Recipeid",
                table: "Usedingredient",
                column: "Recipeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Missedingredient");

            migrationBuilder.DropTable(
                name: "Mix");

            migrationBuilder.DropTable(
                name: "SavedDrinks");

            migrationBuilder.DropTable(
                name: "Unusedingredient");

            migrationBuilder.DropTable(
                name: "Usedingredient");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "CocktailDescription");

            migrationBuilder.DropTable(
                name: "HomeCook");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
