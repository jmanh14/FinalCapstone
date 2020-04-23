using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EatDrinkApplication.Models;

namespace EatDrinkApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "HomeCook",
                NormalizedName = "HOMECOOK",
            }
            );
            builder.Entity<Cuisines>()
                .HasData(
                new Cuisines { CuisinesId = 1, Name = "Africian" },
                new Cuisines { CuisinesId = 2, Name = "American" },
                new Cuisines { CuisinesId = 3, Name = "British" },
                new Cuisines { CuisinesId = 4, Name = "Cajun" },
                new Cuisines { CuisinesId = 5, Name = "Caribbean" },
                new Cuisines { CuisinesId = 6, Name = "Chinese" },
                new Cuisines { CuisinesId = 7, Name = "Eastern European" },
                new Cuisines { CuisinesId = 8, Name = "European" },
                new Cuisines { CuisinesId = 9, Name = "French" },
                new Cuisines { CuisinesId = 10, Name = "German" },
                new Cuisines { CuisinesId = 11, Name = "Greek" },
                new Cuisines { CuisinesId = 12, Name = "Indian" },
                new Cuisines { CuisinesId = 13, Name = "Irish" },
                new Cuisines { CuisinesId = 14, Name = "Italian" },
                new Cuisines { CuisinesId = 15, Name = "Japanese" },
                new Cuisines { CuisinesId = 16, Name = "Jewish" },
                new Cuisines { CuisinesId = 17, Name = "Korean" },
                new Cuisines { CuisinesId = 18, Name = "Latin American" },
                new Cuisines { CuisinesId = 19, Name = "Mediterranean" },
                new Cuisines { CuisinesId = 20, Name = "Mexican" },
                new Cuisines { CuisinesId = 21, Name = "Middle Eastern" },
                new Cuisines { CuisinesId = 22, Name = "Nordic" },
                new Cuisines { CuisinesId = 23, Name = "Southern" },
                new Cuisines { CuisinesId = 24, Name = "Spanish" },
                new Cuisines { CuisinesId = 25, Name = "Thai" },
                new Cuisines { CuisinesId = 26, Name = "Vietnamese" }
                );
        }
        public DbSet<EatDrinkApplication.Models.HomeCook> HomeCook { get; set; }
        public DbSet<EatDrinkApplication.Models.Cocktails> Cocktails { get; set; }
        public DbSet<EatDrinkApplication.Models.CocktailDescription> CocktailDescription { get; set; }
        public DbSet<EatDrinkApplication.Models.SavedDrinks> SavedDrinks { get; set; }
        public DbSet<EatDrinkApplication.Models.Foods> Foods { get; set; }
        public DbSet<EatDrinkApplication.Models.Ingredients> Ingredients { get; set; }
        public DbSet<EatDrinkApplication.Models.SavedFoods> SavedFoods { get; set; }
        public DbSet<EatDrinkApplication.Models.ShoppingCart> ShoppingCart { get; set; }
        public DbSet<EatDrinkApplication.Models.Cuisines> Cuisines { get; set; }
    }
}
