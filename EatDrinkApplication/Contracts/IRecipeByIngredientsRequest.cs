using EatDrinkApplication.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Contracts
{
    public interface IRecipeByIngredientsRequest
    {
        Task<List<JObject>> GetRecipesByIngredients(string ingredients);
    }
}
