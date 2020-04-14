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
    public class CocktailDescriptionRequest : ICocktailDescriptionRequest
    {
        public CocktailDescriptionRequest()
        {

        }
        public async Task<CocktailDescription> GetCocktailDescription(string id)
        {
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                CocktailDescription cocktailDesc = JsonConvert.DeserializeObject<CocktailDescription>(json);
                return cocktailDesc;
            }
            return null;
        }
    }


}
