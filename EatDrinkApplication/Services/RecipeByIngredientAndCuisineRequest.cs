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
    public class RecipeByIngredientAndCuisineRequest : IRecipeByIngredientAndCuisineRequest
    {
        public RecipeByIngredientAndCuisineRequest()
        {

        }
        public async Task<Meals> GetRecipesByIngredientAndCuisine(string ingredients, string cuisine)
        {
            string url = $"https://api.spoonacular.com/recipes/complexSearch?includeIngredients={ingredients}&cuisine={cuisine}&number=10&apiKey={APIKEYS.spoonKey}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Meals meals = JsonConvert.DeserializeObject<Meals>(json);
                return meals;
            }
            return null;
        }
    }
}
