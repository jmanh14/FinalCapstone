using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Models
{
    public class SavedDrinks
    {
        public int SavedDrinksId { get; set; }
        public string Name { get; set; }
        public string? Ingredient1 { get; set; }
        public string? Ingredient2 { get; set; }
        public string? Ingredient3 { get; set; }
        public string? Ingredient4 { get; set; }
        public string? Ingredient5 { get; set; }
        public string? Ingredient6 { get; set; }
        public string? Ingredient7 { get; set; }
        public string? Ingredient8 { get; set; }
        public string? Ingredient9 { get; set; }
        public string? Ingredient10 { get; set; }
        public string? Ingredient11{ get; set; }
        public string? Ingredient12{ get; set; }
        public string? Ingredient13{ get; set; }
        public string? Ingredient14{ get; set; }
        public string? Ingredient15{ get; set; }
        public string Recipe { get; set; }

        [ForeignKey("HomeCook")]
        public int HomeCookId { get; set; }
        public HomeCook HomeCook { get; set; }
    }
}
