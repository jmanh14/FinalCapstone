using EatDrinkApplication.Contracts;
using EatDrinkApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EatDrinkApplication.Services
{
    public class RecipeByIngredientsRequest : IRecipeByIngredientsRequest
    {
        public RecipeByIngredientsRequest()
        {
                    
        }

        public async Task<Foods> GetRecipesByIngredients()
        {
            string url = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients=apples,+flour,+sugar&number=2&apiKey=44486bab87864bd2828d594c8e459825";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Foods foods = JsonConvert.DeserializeObject<Foods>(json);
                return foods;
            }
            return null;
        }
    }
}
