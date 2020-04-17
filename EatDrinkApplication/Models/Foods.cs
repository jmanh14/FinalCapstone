using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Models
{

    public class Foods
    {
        public int FoodsId { get; set; }
        public Recipe[] Property1 { get; set; }
    }

    public class Recipe
    {
        public int RecipeId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public Missedingredient[] missedIngredients { get; set; }
        public Usedingredient[] usedIngredients { get; set; }
        public Unusedingredient[] unusedIngredients { get; set; }
        public int likes { get; set; }
    }

    public class Missedingredient
    {
        public int MissedingredientId { get; set; }
        public int id { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string image { get; set; }
    }

    public class Usedingredient
    {
        public int UsedingredientId { get; set; }
        public int id { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string image { get; set; }
    }

    public class Unusedingredient
    {
        public int UnusedingredientId { get; set; }
        public int id { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public string unitLong { get; set; }
        public string unitShort { get; set; }
        public string aisle { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public string image { get; set; }
    }

}
