
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDrinkApplication.Models
{

    public class DrinkIngredient
    {
        public int DrinkIngredientId { get; set; }
        public MixedDrink[] drinks { get; set; }
    }

    public class MixedDrink
    {
        public int MixedDrinkId { get; set; }
        public string strIngredient1 { get; set; }
    }

}
