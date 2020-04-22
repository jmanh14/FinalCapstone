using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EatDrinkApplication.Data;
using EatDrinkApplication.Models;
using Microsoft.AspNetCore.Authorization;
using EatDrinkApplication.Contracts;
using System.Security.Claims;
using EatDrinkApplication.ViewModel;

namespace EatDrinkApplication.Controllers
{
    [Authorize(Roles = "HomeCook")]
    public class HomeCooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public HomeCooksController(ApplicationDbContext context)
        {
            _context = context;
           
        }

        // GET: HomeCooks
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            if(homeCook == null)
            {
               return RedirectToAction("Create");
            }
            return View(homeCook);
        }

        // GET: HomeCooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCook = await _context.HomeCook
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.HomeCookId == id);
            if (homeCook == null)
            {
                return NotFound();
            }

            return View(homeCook);
        }

        // GET: HomeCooks/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: HomeCooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeCookId,FirstName,LastName,IdentityUserId")] HomeCook homeCook)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                homeCook.IdentityUserId = userId;
                _context.Add(homeCook);
                _context.Add(homeCook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", homeCook.IdentityUserId);
            return View(homeCook);
        }

        public async Task<IActionResult> ViewSavedRecipes()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var savedDrinks = _context.SavedDrinks.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            var savedFoods = _context.SavedFoods.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            SavedRecipesViewModel recipesViewModel = new SavedRecipesViewModel()
            {
                SavedDrinks = savedDrinks,
                SavedFoods = savedFoods
            };
            return View(recipesViewModel);
        }

        public async Task<IActionResult> DeleteFood(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var foodToRemove = _context.SavedFoods.Where(a => a.SavedFoodsId == id).FirstOrDefault();
            _context.SavedFoods.Remove(foodToRemove);
            _context.SaveChanges();
            var savedFoods = _context.SavedFoods.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            var savedDrinks = _context.SavedDrinks.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            SavedRecipesViewModel recipesViewModel = new SavedRecipesViewModel()
            {
                SavedFoods = savedFoods,
                SavedDrinks = savedDrinks
            };
            return View("ViewSavedRecipes", recipesViewModel);
        }

        public async Task<IActionResult> DeleteDrink(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var homeCook = _context.HomeCook.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var drinkToRemove = _context.SavedDrinks.Where(a => a.SavedDrinksId == id).FirstOrDefault();
            _context.SavedDrinks.Remove(drinkToRemove);
            _context.SaveChanges();
            var savedFoods = _context.SavedFoods.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            var savedDrinks = _context.SavedDrinks.Where(a => a.HomeCookId == homeCook.HomeCookId).ToList();
            SavedRecipesViewModel recipesViewModel = new SavedRecipesViewModel()
            {
                SavedFoods = savedFoods,
                SavedDrinks = savedDrinks
            };
            return View("ViewSavedRecipes", recipesViewModel);

        }

        // GET: HomeCooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCook = await _context.HomeCook.FindAsync(id);
            if (homeCook == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", homeCook.IdentityUserId);
            return View(homeCook);
        }

        // POST: HomeCooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HomeCookId,FirstName,LastName,IdentityUserId")] HomeCook homeCook)
        {
            if (id != homeCook.HomeCookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeCook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeCookExists(homeCook.HomeCookId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", homeCook.IdentityUserId);
            return View(homeCook);
        }

        // GET: HomeCooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeCook = await _context.HomeCook
                .Include(h => h.IdentityUser)
                .FirstOrDefaultAsync(m => m.HomeCookId == id);
            if (homeCook == null)
            {
                return NotFound();
            }

            return View(homeCook);
        }

        // POST: HomeCooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeCook = await _context.HomeCook.FindAsync(id);
            _context.HomeCook.Remove(homeCook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeCookExists(int id)
        {
            return _context.HomeCook.Any(e => e.HomeCookId == id);
        }
    }
}
