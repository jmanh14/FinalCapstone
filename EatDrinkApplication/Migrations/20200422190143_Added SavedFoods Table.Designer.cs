﻿// <auto-generated />
using System;
using EatDrinkApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EatDrinkApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200422190143_Added SavedFoods Table")]
    partial class AddedSavedFoodsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EatDrinkApplication.Models.CocktailDescription", b =>
                {
                    b.Property<int>("CocktailDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CocktailDescriptionId");

                    b.ToTable("CocktailDescription");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Cocktails", b =>
                {
                    b.Property<int>("CocktailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CocktailsId");

                    b.ToTable("Cocktails");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CocktailsId")
                        .HasColumnType("int");

                    b.Property<string>("idDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkThumb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrinkId");

                    b.HasIndex("CocktailsId");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Foods", b =>
                {
                    b.Property<int>("FoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("FoodsId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.HomeCook", b =>
                {
                    b.Property<int>("HomeCookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeCookId");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("HomeCook");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Ingredients", b =>
                {
                    b.Property<int>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IdIngredient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientsId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Missedingredient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MissedingredientId")
                        .HasColumnType("int");

                    b.Property<int?>("Recipeid")
                        .HasColumnType("int");

                    b.Property<string>("aisle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Recipeid");

                    b.ToTable("Missedingredient");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Mix", b =>
                {
                    b.Property<int>("MixId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CocktailDescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("dateModified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("idDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strAlcoholic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strCreativeCommonsConfirmed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkAlternate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkDE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkFR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkThumb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkZHHANS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strDrinkZHHANT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strGlass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIBA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strIngredient9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructionsDE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructionsES")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructionsFR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructionsZHHANS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strInstructionsZHHANT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strMeasure9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strTags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MixId");

                    b.HasIndex("CocktailDescriptionId");

                    b.ToTable("Mix");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Recipe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FoodsId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("likes")
                        .HasColumnType("int");

                    b.Property<int>("missedIngredientCount")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("usedIngredientCount")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FoodsId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.SavedDrinks", b =>
                {
                    b.Property<int>("SavedDrinksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HomeCookId")
                        .HasColumnType("int");

                    b.Property<string>("Ingredient1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredient9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SavedDrinksId");

                    b.HasIndex("HomeCookId");

                    b.ToTable("SavedDrinks");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.SavedFoods", b =>
                {
                    b.Property<int>("SavedFoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HomeCookId")
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SavedFoodsId");

                    b.HasIndex("HomeCookId");

                    b.ToTable("SavedFoods");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Unusedingredient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Recipeid")
                        .HasColumnType("int");

                    b.Property<int>("UnusedingredientId")
                        .HasColumnType("int");

                    b.Property<string>("aisle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Recipeid");

                    b.ToTable("Unusedingredient");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Usedingredient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Recipeid")
                        .HasColumnType("int");

                    b.Property<int>("UsedingredientId")
                        .HasColumnType("int");

                    b.Property<string>("aisle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("originalString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitLong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitShort")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Recipeid");

                    b.ToTable("Usedingredient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "02efc056-49e2-4a4c-9b09-57b80603bae4",
                            ConcurrencyStamp = "b9d8b9d0-6942-44e1-b367-70fd56baa4a6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d2a6f78b-7610-45da-b744-7757bdec4eeb",
                            ConcurrencyStamp = "d22d74bf-3781-4442-bdb7-513ea2d7719f",
                            Name = "HomeCook",
                            NormalizedName = "HOMECOOK"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Drink", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.Cocktails", null)
                        .WithMany("drinks")
                        .HasForeignKey("CocktailsId");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.HomeCook", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Missedingredient", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.Recipe", null)
                        .WithMany("missedIngredients")
                        .HasForeignKey("Recipeid");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Mix", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.CocktailDescription", null)
                        .WithMany("drinks")
                        .HasForeignKey("CocktailDescriptionId");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Recipe", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.Foods", null)
                        .WithMany("Property1")
                        .HasForeignKey("FoodsId");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.SavedDrinks", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.HomeCook", "HomeCook")
                        .WithMany()
                        .HasForeignKey("HomeCookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EatDrinkApplication.Models.SavedFoods", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.HomeCook", "HomeCook")
                        .WithMany()
                        .HasForeignKey("HomeCookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Unusedingredient", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.Recipe", null)
                        .WithMany("unusedIngredients")
                        .HasForeignKey("Recipeid");
                });

            modelBuilder.Entity("EatDrinkApplication.Models.Usedingredient", b =>
                {
                    b.HasOne("EatDrinkApplication.Models.Recipe", null)
                        .WithMany("usedIngredients")
                        .HasForeignKey("Recipeid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}