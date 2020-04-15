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
    public class CocktailIngredientRequest : ICocktailIngredientRequest
    {
        public CocktailIngredientRequest()
        {

        }

        public async Task<DrinkIngredient> GetDrinkIngredient()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/list.php?i=list";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                DrinkIngredient ingredient = JsonConvert.DeserializeObject<DrinkIngredient>(json);
                return ingredient;
            }
            return null;
        }
    }
}
