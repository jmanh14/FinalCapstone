﻿using EatDrinkApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.ViewModel
{
    public class FoodViewModel
    {
        public Meals Meals { get; set; }
        public RecipeInfo RecipeInfo { get; set; }
        public List<SelectListItem> Ingredients { get; set; }
        public List<SelectListItem> Cuisines { get; set; }
        public HomeCook HomeCook { get; set; }
        public string SelectedIngredient { get; set; }
        public string SelectedCuisine { get; set; }
    }
}
