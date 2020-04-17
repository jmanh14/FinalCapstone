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
        }
        public DbSet<EatDrinkApplication.Models.HomeCook> HomeCook { get; set; }
        public DbSet<EatDrinkApplication.Models.Cocktails> Cocktails { get; set; }
        public DbSet<EatDrinkApplication.Models.CocktailDescription> CocktailDescription { get; set; }
        public DbSet<EatDrinkApplication.Models.SavedDrinks> SavedDrinks { get; set; }
        public DbSet<EatDrinkApplication.Models.Foods> Foods { get; set; }
    }
}
