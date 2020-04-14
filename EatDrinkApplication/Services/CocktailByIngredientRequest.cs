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
    public class CocktailByIngredientRequest : ICocktailByIngredientRequest
    {
        public CocktailByIngredientRequest()
        {

        }
        public async Task<Cocktails> GetCocktailsByIngredients()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=Vodka";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Cocktails cocktails = JsonConvert.DeserializeObject<Cocktails>(json);
                return cocktails;
            }
            return null;
        }
    }
}
