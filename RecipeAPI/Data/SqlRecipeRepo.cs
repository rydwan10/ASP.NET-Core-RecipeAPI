using RecipeAPI.Context;
using RecipeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeAPI.Data
{
    public class SqlRecipeRepo : IRecipeRepo
    {
        private readonly RecipeContext _context;

        public SqlRecipeRepo(RecipeContext context)
        {
            _context = context;
        }

        public async Task CreateRecipe(Recipe recipe)
        {
           if (recipe == null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }
            await _context.Recipes.AddAsync(recipe);
        }

        public void DeleteRecipe(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var result = await _context.Recipes.Include(c => c.Chef).ToListAsync();
            return result;
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            var result = await _context.Recipes.Include(c => c.Chef).FirstOrDefaultAsync(x => x.Id == id);
            
            return result;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public void UpdateRecipe(Recipe recipe)
        {
            //
        }
    }
}
