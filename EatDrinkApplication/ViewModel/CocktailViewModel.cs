using EatDrinkApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.ViewModel
{
    public class CocktailViewModel
    {
        public Cocktails Cocktail { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

        public string SelectedIngredient { get; set; }
    }
}
