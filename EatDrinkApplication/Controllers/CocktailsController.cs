﻿using System;
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
            
            
            DrinkIngredient ingredient = await _cocktailIngredientRequest.GetDrinkIngredient();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = ingredient.drinks.Select(a => new SelectListItem()
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
                Ingredients = ingredients
            };
            return View(cocktailView);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CocktailViewModel cocktailView)
        {
            Cocktails cocktails = await _cocktailByIngredientRequest.GetCocktailsByIngredients(cocktailView.SelectedIngredient);
            DrinkIngredient ingredient = await _cocktailIngredientRequest.GetDrinkIngredient();
            List<SelectListItem> ingredients = new List<SelectListItem>();
            var _ingredients = ingredient.drinks.Select(a => new SelectListItem()
            {
                Text = a.strIngredient1,
                Value = a.strIngredient1
            });
            ingredients = _ingredients.OrderBy(a => a.Text).ToList();
            cocktailView.Cocktail = cocktails;
            cocktailView.Ingredients = ingredients;
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