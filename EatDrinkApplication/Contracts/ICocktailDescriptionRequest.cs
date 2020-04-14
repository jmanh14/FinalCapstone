using EatDrinkApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EatDrinkApplication.Contracts
{
    public interface ICocktailDescriptionRequest
    {
        Task<CocktailDescription> GetCocktailDescription(string id);
    }
}
