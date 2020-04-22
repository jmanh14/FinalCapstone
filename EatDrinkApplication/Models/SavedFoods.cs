using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Models
{
    public class SavedFoods
    {
        public int SavedFoodsId { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Recipe { get; set; }
        
        [ForeignKey("HomeCook")]
        public int HomeCookId { get; set; }
        public HomeCook HomeCook { get; set; }
    }
}
