using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EatDrinkApplication.Data;
using EatDrinkApplication.Models;
using EatDrinkApplication.Contracts;
using EatDrinkApplication.ViewModel;
using System.Security.Claims;

namespace EatDrinkApplication.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICocktailByIngredientRequest _cocktailByIngredientRequest;
        private readonly ICocktailDescriptionRequest _cocktailDescriptionRequest;
        private readonly ICocktailIngredientRequest _cocktailIngredientRequest;

        public CocktailsController(ApplicationDbContext context, ICocktailByIngredientRequest cocktailByIngredientRequest, ICocktailDescriptionRequest cocktailDescriptionRequest, ICocktailIngredientRequest cocktailIngredientRequest)
        {
            _context = context;
            _cocktailByIngredientRequest = cocktailByIngredientRequest;
            _cocktailDescriptionRequest = cocktailDescriptionRequest;
            _cocktailIngredientRequest = cocktailIngredientRequest;
        }

        // GET: Cocktails
        public async Task<IActionResult> Index()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            DrinkIngredient drinkIngredient = await _cocktailIngredientRequest.GetDrinkIngredient();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = drinkIngredient.drinks.Select(a => new SelectListItem()
            {
                Text = a.strIngredient1,
                Value = a.strIngredient1
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList(); 
            string selectedIngredient = ingredients.Select(a => a.Value).FirstOrDefault().ToString();
            Cocktails cocktails = await _cocktailByIngredientRequest.GetCocktailsByIngredients(selectedIngredient);
            CocktailViewModel cocktailView = new CocktailViewModel()
            {
                Cocktail = cocktails,  
                Ingredients = ingredients,
                HomeCook = homeCook
            };
            return View(cocktailView);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CocktailViewModel cocktailView)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            Cocktails cocktails = await _cocktailByIngredientRequest.GetCocktailsByIngredients(cocktailView.SelectedIngredient);
            DrinkIngredient drinkIngredient = await _cocktailIngredientRequest.GetDrinkIngredient();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = drinkIngredient.drinks.Select(a => new SelectListItem()
            {
                Text = a.strIngredient1,
                Value = a.strIngredient1
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            cocktailView.Cocktail = cocktails;
            cocktailView.Ingredients = ingredients;
            cocktailView.HomeCook = homeCook;
            return View(cocktailView);
        }

        // GET: Cocktails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CocktailDescription cocktail = await _cocktailDescriptionRequest.GetCocktailDescription(id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        public async Task<IActionResult> SaveDrink(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            CocktailDescription cocktail = await _cocktailDescriptionRequest.GetCocktailDescription(id);
            CocktailViewModel cocktailView = new CocktailViewModel()
            {
                CocktailDescription = cocktail,
                HomeCook = homeCook
            };
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktailView);

        }
        [HttpPost]
        public async Task<IActionResult> SaveDrink(CocktailViewModel cocktailView)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            cocktailView.HomeCook = homeCook;
            _context.SavedDrinks.Add(new SavedDrinks() {
                Name = cocktailView.CocktailDescription.drinks[0].strDrink,
                Ingredient1 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure1} {cocktailView.CocktailDescription.drinks[0].strIngredient1}",
                Ingredient2 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure2} {cocktailView.CocktailDescription.drinks[0].strIngredient2}",
                Ingredient3 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure3} {cocktailView.CocktailDescription.drinks[0].strIngredient3}",
                Ingredient4 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure4} {cocktailView.CocktailDescription.drinks[0].strIngredient4}",
                Ingredient5 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure5} {cocktailView.CocktailDescription.drinks[0].strIngredient5}",
                Ingredient6 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure6} {cocktailView.CocktailDescription.drinks[0].strIngredient6}",
                Ingredient7 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure7} {cocktailView.CocktailDescription.drinks[0].strIngredient7}",
                Ingredient8 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure8} {cocktailView.CocktailDescription.drinks[0].strIngredient8}",
                Ingredient9 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure9} {cocktailView.CocktailDescription.drinks[0].strIngredient9}",
                Ingredient10 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure10} {cocktailView.CocktailDescription.drinks[0].strIngredient10}",
                Ingredient11 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure11} {cocktailView.CocktailDescription.drinks[0].strIngredient11}",
                Ingredient12 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure12} {cocktailView.CocktailDescription.drinks[0].strIngredient12}",
                Ingredient13 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure13} {cocktailView.CocktailDescription.drinks[0].strIngredient13}",
                Ingredient14 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure14} {cocktailView.CocktailDescription.drinks[0].strIngredient14}",
                Ingredient15 = $"{cocktailView.CocktailDescription.drinks[0].strMeasure15} {cocktailView.CocktailDescription.drinks[0].strIngredient15}",
                HomeCook = homeCook 
            });
            DrinkIngredient drinkIngredient = await _cocktailIngredientRequest.GetDrinkIngredient();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = drinkIngredient.drinks.Select(a => new SelectListItem()
            {
                Text = a.strIngredient1,
                Value = a.strIngredient1
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            string selectedIngredient = ingredients.Select(a => a.Value).FirstOrDefault().ToString();
            Cocktails cocktails = await _cocktailByIngredientRequest.GetCocktailsByIngredients(selectedIngredient);
            cocktailView.Cocktail = cocktails;
            cocktailView.Ingredients = ingredients;
            _context.SaveChanges();
            return View("Index", cocktailView);
        }
        // GET: Cocktails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CocktailsId")] Cocktails cocktails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cocktails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocktails);
        }

        // GET: Cocktails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktails = await _context.Cocktails.FindAsync(id);
            if (cocktails == null)
            {
                return NotFound();
            }
            return View(cocktails);
        }

        // POST: Cocktails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CocktailsId")] Cocktails cocktails)
        {
            if (id != cocktails.CocktailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocktails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailsExists(cocktails.CocktailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cocktails);
        }

        // GET: Cocktails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktails = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.CocktailsId == id);
            if (cocktails == null)
            {
                return NotFound();
            }

            return View(cocktails);
        }

        // POST: Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cocktails = await _context.Cocktails.FindAsync(id);
            _context.Cocktails.Remove(cocktails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocktailsExists(int id)
        {
            return _context.Cocktails.Any(e => e.CocktailsId == id);
        }
    }
}
