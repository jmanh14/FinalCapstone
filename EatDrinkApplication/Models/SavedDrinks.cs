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
        public CocktailDescription CocktailDescription { get; set; }
        
        [ForeignKey("HomeCook")]
        public int HomeCookId { get; set; }
        public HomeCook HomeCook { get; set; }
    }
}
