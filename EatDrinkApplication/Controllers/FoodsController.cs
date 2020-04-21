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

namespace EatDrinkApplication.Controllers
{
    public class FoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public readonly IRecipeByIngredientsRequest _recipeByIngredientsRequest;

        public FoodsController(ApplicationDbContext context, IRecipeByIngredientsRequest recipeByIngredientsRequest)
        {
            _context = context;
            _recipeByIngredientsRequest = recipeByIngredientsRequest;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var foods = await _recipeByIngredientsRequest.GetRecipesByIngredients();
            Recipe recipe = foods[0].ToObject<Recipe>();
            Recipe[] recipes;
            recipes = new Recipe[] { recipe };
            Foods food = new Foods()
            {
                Property1 = recipes
            };
            return View(food.Property1);
        }

        // GET: Foods/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Foods/Create
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
