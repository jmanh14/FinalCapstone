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
using System.Security.Claims;
using EatDrinkApplication.Helper;
using EatDrinkApplication.ViewModel;

namespace EatDrinkApplication.Controllers
{
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public readonly IRecipeByIngredientsRequest _recipeByIngredientsRequest;
        public readonly IRecipeInfoRequest _recipeInfoRequest;
        public readonly IRecipeByIngredientAndCuisineRequest _recipeByIngredientAndCuisineRequest;

        public FoodsController(ApplicationDbContext context, IRecipeByIngredientsRequest recipeByIngredientsRequest, IRecipeInfoRequest recipeInfoRequest, IRecipeByIngredientAndCuisineRequest recipeByIngredientAndCuisineRequest)
        {
            _context = context;
            _recipeByIngredientsRequest = recipeByIngredientsRequest;
            _recipeInfoRequest = recipeInfoRequest;
            _recipeByIngredientAndCuisineRequest = recipeByIngredientAndCuisineRequest;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = _context.Ingredients.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            string selectedIngredient = ingredients.Select(a => a.Value).FirstOrDefault().ToString();
            List<SelectListItem> cuisines = new List<SelectListItem>();
            var _cuisines = _context.Cuisines.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            cuisines = _cuisines.OrderBy(a => a.Text).ToList();
            string selectedCuisine = cuisines.Select(a => a.Value).FirstOrDefault().ToString();
            var meals = await _recipeByIngredientAndCuisineRequest.GetRecipesByIngredientAndCuisine(selectedIngredient, selectedCuisine);
            if (_context.Ingredients.Contains(null))
            {
                IngredientIO iO = new IngredientIO(_context);
                iO.ReadFile();
            }
            FoodViewModel foodViewModel = new FoodViewModel()
            {
                Meals = meals,
                Ingredients = ingredients,
                Cuisines = cuisines,
                HomeCook = homeCook
            };
            return View(foodViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FoodViewModel foodViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var meals = await _recipeByIngredientAndCuisineRequest.GetRecipesByIngredientAndCuisine(foodViewModel.SelectedIngredient, foodViewModel.SelectedCuisine);
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = _context.Ingredients.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            List<SelectListItem> cuisines = new List<SelectListItem>();
            var _cuisines = _context.Cuisines.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            cuisines = _cuisines.OrderBy(a => a.Text).ToList();
            foodViewModel.HomeCook = homeCook;
            foodViewModel.Meals = meals;
            foodViewModel.Ingredients = ingredients;
            foodViewModel.Cuisines = cuisines;
            return View(foodViewModel);
        }
        // GET: Foods/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RecipeInfo recipeInfo = await _recipeInfoRequest.GetRecipeInfo(id);
            if (recipeInfo == null)
            {
                return NotFound();
            }

            return View(recipeInfo);
        }

        public async Task<IActionResult> SaveFood(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            RecipeInfo recipeInfo = await _recipeInfoRequest.GetRecipeInfo(id);
            FoodViewModel foodViewModel = new FoodViewModel()
            {
                RecipeInfo = recipeInfo,
                HomeCook = homeCook
            };
            return View(foodViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> SaveFood(FoodViewModel foodViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            string ingredientsFromRecipe = "";
            for (int i = 0; i < foodViewModel.RecipeInfo.extendedIngredients.Length; i++)
            {
                ingredientsFromRecipe += foodViewModel.RecipeInfo.extendedIngredients[i].originalString + " ";
            }
            foodViewModel.HomeCook = homeCook;
            _context.SavedFoods.Add(new SavedFoods()
            {
                Name = foodViewModel.RecipeInfo.title,
                Ingredients = ingredientsFromRecipe,
                Recipe = foodViewModel.RecipeInfo.instructions,
                HomeCook = homeCook
            });
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = _context.Ingredients.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            List<SelectListItem> cuisines = new List<SelectListItem>();
            var _cuisines = _context.Cuisines.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            cuisines = _cuisines.OrderBy(a => a.Text).ToList();
            string selectedIngredient = ingredients.Select(a => a.Value).FirstOrDefault().ToString();
            string selectedCuisine = cuisines.Select(a => a.Value).FirstOrDefault().ToString();
            var meals = await _recipeByIngredientAndCuisineRequest.GetRecipesByIngredientAndCuisine(selectedIngredient, selectedCuisine);
            foodViewModel.Meals = meals;
            foodViewModel.Ingredients = ingredients;
            foodViewModel.Cuisines = cuisines;
            _context.SaveChanges();
            return View("Index", foodViewModel);

        }

        public async Task<IActionResult> Cart (string id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            RecipeInfo recipeInfo = await _recipeInfoRequest.GetRecipeInfo(id);
            string items = "";
            for(int i = 0; i < recipeInfo.extendedIngredients.Length; i++)
            {
                items += recipeInfo.extendedIngredients[i].originalString + " , ";
            }
            ShoppingCart cart = _context.ShoppingCart.Where(a => a.HomeCookId == homeCook.HomeCookId).FirstOrDefault();
            if (cart == null)
            {
                cart = new ShoppingCart()
                {
                    Items = items,
                    HomeCook = homeCook
                };
                _context.ShoppingCart.Add(cart);
            }
            else
            {
                cart.Items += items;
                cart.HomeCook = homeCook;
                _context.ShoppingCart.Update(cart);
            }
            _context.SaveChanges();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = _context.Ingredients.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            List<SelectListItem> cuisines = new List<SelectListItem>();
            var _cuisines = _context.Cuisines.Select(a => new SelectListItem()
            {
                Text = a.Name,
                Value = a.Name
            });
            cuisines = _cuisines.OrderBy(a => a.Text).ToList();
            string selectedIngredient = ingredients.Select(a => a.Value).FirstOrDefault().ToString();
            string selectedCuisine = cuisines.Select(a => a.Value).FirstOrDefault().ToString();
            var meals = await _recipeByIngredientAndCuisineRequest.GetRecipesByIngredientAndCuisine(selectedIngredient, selectedCuisine);
            if (_context.Ingredients.Contains(null))
            {
                IngredientIO iO = new IngredientIO(_context);
                iO.ReadFile();
            }
            FoodViewModel foodViewModel = new FoodViewModel()
            {
                Meals = meals,
                Ingredients = ingredients,
                Cuisines = cuisines,
                HomeCook = homeCook
            };
            return View("Index", foodViewModel);
        }

        //GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodsId")] Foods foods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foods);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foods = await _context.Foods.FindAsync(id);
            if (foods == null)
            {
                return NotFound();
            }
            return View(foods);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodsId")] Foods foods)
        {
            if (id != foods.FoodsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodsExists(foods.FoodsId))
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
            return View(foods);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foods = await _context.Foods
                .FirstOrDefaultAsync(m => m.FoodsId == id);
            if (foods == null)
            {
                return NotFound();
            }

            return View(foods);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foods = await _context.Foods.FindAsync(id);
            _context.Foods.Remove(foods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodsExists(int id)
        {
            return _context.Foods.Any(e => e.FoodsId == id);
        }
    }
}
