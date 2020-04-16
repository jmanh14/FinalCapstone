
using System.ComponentModel.DataAnnotations.Schema;

namespace EatDrinkApplication.Models
{

    public class Cocktails
    {
        public int CocktailsId { get; set; }
        public Drink[] drinks { get; set; }
    }

    public class Drink
    {
        public int DrinkId { get; set; }
        public string strDrink { get; set; }
        public string strDrinkThumb { get; set; }
        public string idDrink { get; set; }
    }

}
