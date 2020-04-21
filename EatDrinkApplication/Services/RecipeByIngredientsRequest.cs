using EatDrinkApplication.Contracts;
using EatDrinkApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<List<JObject>> GetRecipesByIngredients()
        {
            string url = $"https://api.spoonacular.com/recipes/findByIngredients?ingredients=apples,+flour,+sugar&number=2&apiKey=44486bab87864bd2828d594c8e459825";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                json = "{" + "results :" + json + "}";
                var jsonResults = JsonConvert.DeserializeObject<JObject>(json);
                List<JObject> foods = new List<JObject>();
                for(int i =0; i< jsonResults.Count; i++)
                {
                    foods.Add(jsonResults["results"][i].ToObject<JObject>());
                }
                //var results = jsonResults["results"][0];
                //var test = jsonResults["missedIngredients"];  
                //List<JObject> test = new List<JObject>();
                //for (int i = 0; i < jsonResults.Count; i++)
                //{
                //    test.Add(jsonResults[i].ToObject<JObject>());
                //}
                //Console.WriteLine(foods[0]["title"]);
                return foods;
            }
            return null;   
        }
    }
}
