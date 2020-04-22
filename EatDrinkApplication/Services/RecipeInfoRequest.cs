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
    public class RecipeInfoRequest : IRecipeInfoRequest
    {
        public RecipeInfoRequest()
        {

        }
        public async Task<RecipeInfo> GetRecipeInfo(string id)
        {
            string url = $"https://api.spoonacular.com/recipes/{id}/information?includeNutrition=false&apiKey=44486bab87864bd2828d594c8e459825";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                RecipeInfo recipeInfo = JsonConvert.DeserializeObject<RecipeInfo>(json);
                return recipeInfo;
            }
            return null;
        }
    }
}
