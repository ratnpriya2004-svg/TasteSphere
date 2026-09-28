using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TasteSphere.Data;
using TasteSphere.Models;

namespace TasteSphere.Controllers
{
    public class HomeController : Controller
    {
        private readonly OracleDbContext _context;

        public HomeController(OracleDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var query = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Cuisine)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(r =>
                    r.RecipeName.Contains(search) ||
                    (r.Description != null && r.Description.Contains(search)) ||
                    (r.Cuisine != null && r.Cuisine.CuisineName.Contains(search)) ||
                    (r.Cuisine != null && r.Cuisine.CountryName.Contains(search)));
            }

            var recipes = await query.ToListAsync();

            ViewBag.Search = search;

            ViewBag.Cuisines = await _context.Cuisines
    .OrderBy(c => c.CountryName)
    .ToListAsync();
            return View(recipes);
        }


        public async Task<IActionResult> Country(int id)
        {
            var cuisine = await _context.Cuisines
                .FirstOrDefaultAsync(c => c.CuisineId == id);

            if (cuisine == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.CuisineId == id)
                .ToListAsync();

            ViewBag.Recipes = recipes;

            return View(cuisine);
        }


        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Cuisine)
                .FirstOrDefaultAsync(r => r.RecipeId == id);

            if (recipe == null)
            {
                return NotFound();
            }

            var ingredients = await _context.RecipeIngredients
                .Include(ri => ri.Ingredient)
                .Where(ri => ri.RecipeId == id)
                .ToListAsync();

            var steps = await _context.RecipeSteps
                .Where(rs => rs.RecipeId == id)
                .OrderBy(rs => rs.StepNumber)
                .ToListAsync();

            ViewBag.Ingredients = ingredients;
            ViewBag.Steps = steps;

            return View("~/Views/Home/Details.cshtml", recipe);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}